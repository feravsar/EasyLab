using System.Linq;
using System.Threading.Tasks;
using EasyLab.Core.Dto;
using EasyLab.Core.Dto.GatewayResponses.Repositories;
using EasyLab.Core.Entities;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EasyLab.Core.Specifications;
using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.Entity;

namespace EasyLab.Infrastructure.Data.Repositories
{
    public sealed class UserRepository : EfRepository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public UserRepository(UserManager<User> userManager, IMapper mapper, AppDbContext appDbContext) : base(appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Create(string username, string name, string surname, string email, string password)
        {
            User appUser = new User
            {
                Email = email,
                UserName = username,
                Name = name,
                Surname = surname
            };


            IdentityResult identityResult = await _userManager.CreateAsync(appUser, password);

            if (!identityResult.Succeeded)
                return new CreateUserResponse(appUser.Id, false, identityResult.Errors.Select(e => new Error(e.Code, e.Description)));


            return new CreateUserResponse(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<User> FindByName(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            return appUser == null ? null : _mapper.Map(appUser, await GetSingleBySpec(new UserSpecification(appUser.Id)));
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<User>(user), password);
        }

        public async Task<IdentityResult> ChangePassword(User user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<User> GetUserWithIdentifer(string userIdentifier)
        {
            return await Queryable().FirstOrDefaultAsync(t => t.Email == userIdentifier || t.PhoneNumber == userIdentifier || t.Id == Guid.Parse(userIdentifier));
        }

        public async Task<bool> CheckDuplicateMail(string email)
        {
            return await Queryable().AnyAsync(t => t.Email == email);
        }

        public async Task<bool> CheckDuplicatePhoneNumber(string phoneNumber)
        {
            return await Queryable().AnyAsync(t => t.PhoneNumber == phoneNumber);
        }

        public async Task<IList<String>> GetUserRoles(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<List<UserDto>> Search(string searchTerm)
        {
            return await Queryable().Where(t =>
                EF.Functions.Like(t.Name, "%" + searchTerm + "%") ||
                EF.Functions.Like(t.Surname, "%" + searchTerm + "%") ||
                EF.Functions.Like(t.Email, "%" + searchTerm + "%") ||
                EF.Functions.Like(t.UserName, "%" + searchTerm + "%"))
                .Select(t => new UserDto(t.Id, t.Email, t.UserName, t.Name, t.Surname))
                .Take(50)
                .ToListAsync();
        }


    }
}

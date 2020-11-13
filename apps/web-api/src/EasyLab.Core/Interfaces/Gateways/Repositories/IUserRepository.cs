using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Dto.GatewayResponses.Repositories;
using EasyLab.Core.Entities;

namespace EasyLab.Core.Interfaces.Gateways.Repositories{

     public interface IUserRepository  : IEfRepository<User>
    {
        Task<CreateUserResponse> Create(string username,string name, string surname, string email, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
        Task<User> GetUserWithIdentifer(string userIdentifier);
        Task<bool> CheckDuplicateMail(string email);
        Task<bool> CheckDuplicatePhoneNumber(string phoneNumber);
        Task<IdentityResult> ChangePassword(User user, string oldPassword, string newPassword);
        Task<IList<String>> GetUserRoles(User user);
        Task<List<UserDto>> Search(string searchTerm);
    }

}

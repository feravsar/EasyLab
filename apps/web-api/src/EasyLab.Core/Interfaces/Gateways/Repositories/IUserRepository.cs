using System.Threading.Tasks;
using EasyLab.Core.Dto.GatewayResponses.Repositories;
using EasyLab.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace EasyLab.Core.Interfaces.Gateways.Repositories{

     public interface IUserRepository  : IEfRepository<User>
    {
        Task<CreateUserResponse> Create(string name, string surname, string email, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
        Task<User> GetUserWithIdentifer(string userIdentifier);
        Task<bool> CheckDuplicateMail(string email);
        Task<bool> CheckDuplicatePhoneNumber(string phoneNumber);
        Task<IdentityResult> ChangePassword(User user, string oldPassword, string newPassword);
    }

}

using EasyLab.Core.Dto.UseCaseResponses.Auth;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Auth{
    public class UserLoginRequest : IUseCaseRequest<UserLoginResponse>{
        public string  Email { get; }

        public string Password { get; }

        public string RemoteIpAddress { get; }


        public UserLoginRequest(string email, string password, string remoteIpAddress){
            Email = email;
            Password = password;
            RemoteIpAddress = remoteIpAddress;
        }

    }
}
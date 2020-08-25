using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests{
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
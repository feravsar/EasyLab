using EasyLab.Core.Dto.UseCaseResponses.Account;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Account
{
    public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
    {
        public RegisterUserRequest(string username, string name, string surname, string email, string password)
        {
            Username = username;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }

        public string Username { get; private set; }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        public string Password { get; }

  
    }
}

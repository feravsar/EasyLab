using EasyLab.Core.Dto.UseCaseRequests.Account;
using EasyLab.Core.Dto.UseCaseResponses.Account;

namespace EasyLab.Core.Interfaces.UseCases.Account
{

    public interface IRegisterUserHandler : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
    }

}

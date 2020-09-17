using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;

namespace EasyLab.Core.Interfaces.UseCases.User{

    public interface ISearchUserHandler : IUseCaseRequestHandler<SearchUserRequest,SearchUserResponse>{
        
    }
}
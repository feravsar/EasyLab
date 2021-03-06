using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests.Teacher;
using EasyLab.Core.Dto.UseCaseResponses.Teacher;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Teacher;

namespace EasyLab.Core.UseCases.Teacher{
    public sealed class SearchUserHandler : ISearchUserHandler
    {
        private readonly IUserRepository _userRepository;

        public SearchUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(SearchUserRequest request, IOutputPort<SearchUserResponse> outputPort)
        {
           var result = await _userRepository.Search(request.SearchTerm);

           outputPort.Handle(new SearchUserResponse(result));
        }
    }
}
using System;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests
{
    public class SearchUserRequest : IUseCaseRequest<SearchUserResponse>
    {
        public SearchUserRequest(string searchTerm)
        {
            SearchTerm = searchTerm;
        }

        public string SearchTerm { get; private set; }
    }
}

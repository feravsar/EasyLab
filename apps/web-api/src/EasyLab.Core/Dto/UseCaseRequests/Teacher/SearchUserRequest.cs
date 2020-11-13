using System;

using EasyLab.Core.Dto.UseCaseResponses.Teacher;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Teacher
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

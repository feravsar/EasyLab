using System;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests
{
    public class GetAuthoredCoursesRequest : IUseCaseRequest<GetAuthoredCoursesResponse>
    {
        public Guid AuthorId { get; }


        public GetAuthoredCoursesRequest(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}

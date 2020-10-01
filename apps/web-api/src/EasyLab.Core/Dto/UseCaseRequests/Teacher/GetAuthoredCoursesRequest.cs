using System;

using EasyLab.Core.Dto.UseCaseResponses.Teacher;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Teacher
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

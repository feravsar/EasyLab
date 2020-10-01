using System;

using EasyLab.Core.Dto.UseCaseResponses.Student;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Student
{
    public class GetProjectsRequest : IUseCaseRequest<GetProjectsResponse>
    {
        public GetProjectsRequest(Guid userId, Guid courseId)
        {
            UserId = userId;
            CourseId = courseId;
        }

        public Guid UserId { get; private set; }

        public Guid CourseId { get; private set; }
    }
}

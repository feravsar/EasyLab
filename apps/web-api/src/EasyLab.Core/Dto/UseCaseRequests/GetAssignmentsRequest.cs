using System;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests{
    public class GetAssignmentsRequest : IUseCaseRequest<GetAssignmentsResponse>{
        public GetAssignmentsRequest(Guid userId, Guid courseId)
        {
            UserId = userId;
            CourseId = courseId;
        }

        public Guid UserId { get; private set; }

        public Guid CourseId { get; private set; }
        
    }
}
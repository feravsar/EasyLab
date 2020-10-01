using System;

using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Student
{
    public class StartProjectRequest : IUseCaseRequest<BasicResponse>
    {
        public StartProjectRequest(Guid assignmentId, Guid userId)
        {
            AssignmentId = assignmentId;
            UserId = userId;
        }

        public Guid AssignmentId { get; private set; }
        public Guid UserId { get; private set; }
    }
}

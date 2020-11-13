using System;
using EasyLab.Core.Dto.UseCaseResponses.Student;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Student
{
    public class RunProjectRequest : IUseCaseRequest<RunProjectResponse>
    {
        public RunProjectRequest(Guid projectId, Guid userId)
        {
            ProjectId = projectId;
            UserId = userId;
        }

        public Guid ProjectId { get; private set; }

        public Guid UserId { get; private set; }
    }
}

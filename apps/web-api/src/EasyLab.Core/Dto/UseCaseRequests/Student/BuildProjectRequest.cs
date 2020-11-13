using System;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Student
{
    public class BuildProjectRequest : IUseCaseRequest<BasicResponse>
    {
        public BuildProjectRequest(Guid projectId, Guid userId)
        {
            ProjectId = projectId;
            UserId = userId;
        }

        public Guid ProjectId { get; private set; }

        public Guid UserId { get; private set; }
    }
}

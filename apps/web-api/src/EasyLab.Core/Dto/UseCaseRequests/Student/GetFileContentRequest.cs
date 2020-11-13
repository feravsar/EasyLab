using System;
using EasyLab.Core.Dto.UseCaseResponses.Student;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Student
{
    public class GetFileContentRequest : IUseCaseRequest<GetFileContentResponse>
    {
        public GetFileContentRequest(Guid userId, Guid projectId, string fileName)
        {
            UserId = userId;
            ProjectId = projectId;
            FileName = fileName;
        }

        public Guid UserId { get; private set; }

        public Guid ProjectId { get; private set; }

        public string FileName { get; private set; }
    }
}

using System;
using EasyLab.Core.Dto.UseCaseResponses.Student;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Student
{
    public class UpdateDocumentRequest : IUseCaseRequest<UpdateDocumentResponse>
    {
        public UpdateDocumentRequest(Guid userId, Guid projectId, string fileName, string fileContent)
        {
            UserId = userId;
            ProjectId = projectId;
            FileName = fileName;
            FileContent = "\'" + fileContent + "\'";
        }

        public Guid UserId { get; private set; }

        public Guid ProjectId { get; private set; }

        public string FileName { get; private set; }

        public string FileContent { get; private set; }
        
    }
}

using System;
using EasyLab.Core.Dto.UseCaseRequests.Student;
using EasyLab.Core.Dto.UseCaseResponses.Student;

namespace EasyLab.Core.Interfaces.UseCases.Student
{
    public interface IGetFileContentHandler : IUseCaseRequestHandler<GetFileContentRequest, GetFileContentResponse>
    {
        
    }
}

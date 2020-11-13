using System;
using EasyLab.Core.Dto.UseCaseRequests.Student;
using EasyLab.Core.Dto.UseCaseResponses;

namespace EasyLab.Core.Interfaces.UseCases.Student
{ 
    public interface IBuildProjectHandler : IUseCaseRequestHandler<BuildProjectRequest,BasicResponse>
    {
        
    }
}

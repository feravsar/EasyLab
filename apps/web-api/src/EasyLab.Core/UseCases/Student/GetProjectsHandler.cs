using System;
using System.Threading.Tasks;

using EasyLab.Core.Dto.UseCaseRequests.Student;
using EasyLab.Core.Dto.UseCaseResponses.Student;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Student;

namespace EasyLab.Core.UseCases.Student
{
    public class GetProjectsHandler : IGetProjectsHandler
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public GetProjectsHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task Handle(GetProjectsRequest request, IOutputPort<GetProjectsResponse> outputPort)
        {
            var result = await _assignmentRepository.GetProjects(request.CourseId,request.UserId);

            outputPort.Handle(new GetProjectsResponse(result));
        }
    }
}

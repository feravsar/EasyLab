using System;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Course;

namespace EasyLab.Core.UseCases.Course{
    public sealed class GetAssignmentsHandler : IGetAssignmentsHandler
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IAssignmentRepository _assignmentRepository;

        public GetAssignmentsHandler(ICourseRepository courseRepository, IAssignmentRepository assignmentRepository)
        {
            _courseRepository = courseRepository;
            _assignmentRepository = assignmentRepository;
        }


        public async Task Handle(GetAssignmentsRequest request, IOutputPort<GetAssignmentsResponse> outputPort)
        {
             if (!(await _courseRepository.IsAuthoredAsTeacher(request.UserId, request.CourseId)))
                throw new Exception("You're not authorized for this action");

            var resultSet = await _assignmentRepository.GetAssignments(request.CourseId);

            outputPort.Handle(new GetAssignmentsResponse(resultSet));
        }
    }
}
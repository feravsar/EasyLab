using System;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests.Student;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.Services;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Student;

namespace EasyLab.Core.UseCases.Student
{
    public sealed class StartProjectHandler : IStartProjectHandler
    {
        private readonly IProjectFactory _projectFactory;
        
        private readonly IAssignmentRepository _assignmentRepository;

        private readonly ICourseUserRepository _courseUsersRepository;

        private readonly IProjectRepository _studentAssignmentsRepository;

        public StartProjectHandler(IProjectFactory projectFactory, IAssignmentRepository assignmentRepository, ICourseUserRepository courseUsersRepository, IProjectRepository studentAssignmentsRepository)
        {
            _projectFactory = projectFactory;
            _assignmentRepository = assignmentRepository;
            _courseUsersRepository = courseUsersRepository;
            _studentAssignmentsRepository = studentAssignmentsRepository;
        }

        public async Task Handle(StartProjectRequest request, IOutputPort<BasicResponse> outputPort)
        {

            var assignment = await _assignmentRepository.GetById<Guid>(request.AssignmentId);
            if(assignment == null)
                throw new Exception("Assignment couldn't be found");

            if(!await _courseUsersRepository.IsUserEnrolledCourse(assignment.CourseId, request.UserId))
                throw new Exception("User is not enrolled to this course!");
            
            if(await _studentAssignmentsRepository.IsProjectStarted(request.AssignmentId, request.UserId))
                throw new Exception("User already has a project");

            await _projectFactory.CreateProject(assignment.CourseId.ToString(), assignment.Id.ToString(), request.UserId.ToString());

            await _studentAssignmentsRepository.Add(new Entities.Project{
                AssignmentId = assignment.Id,
                UserId = request.UserId,
                DateStarted = DateTime.UtcNow
            });


            outputPort.Handle(new BasicResponse(true, "Assignment created successfully"));
        }
    }
}
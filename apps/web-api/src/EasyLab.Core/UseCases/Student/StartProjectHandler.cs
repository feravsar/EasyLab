using System;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests.Student;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Entities;
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

        private readonly IProjectRepository _projectRepository;

        private readonly IUserRepository _userRepository;

        public StartProjectHandler(IProjectFactory projectFactory, IAssignmentRepository assignmentRepository, ICourseUserRepository courseUsersRepository, IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectFactory = projectFactory;
            _assignmentRepository = assignmentRepository;
            _courseUsersRepository = courseUsersRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(StartProjectRequest request, IOutputPort<BasicResponse> outputPort)
        {

            var assignment = await _assignmentRepository.GetById<Guid>(request.AssignmentId);

            User user = await _userRepository.GetById<Guid>(request.UserId);

            if(assignment == null)
                throw new Exception("Assignment couldn't be found");

            if(!await _courseUsersRepository.IsUserEnrolledCourse(assignment.CourseId, request.UserId))
                throw new Exception("User is not enrolled to this course!");
            
            if(await _projectRepository.IsProjectStarted(request.AssignmentId, request.UserId))
                throw new Exception("User already has a project");

            Guid projectId = Guid.NewGuid();

            await _projectFactory.CreateProject(user.UserName, projectId.ToString());

            await _projectRepository.Add(new Entities.Project{
                ProjectId = projectId,
                AssignmentId = assignment.Id,
                UserId = request.UserId,
                DateStarted = DateTime.UtcNow
            });

            outputPort.Handle(new BasicResponse(true, "Assignment created successfully"));
        }
    }
}
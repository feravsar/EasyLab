using System;
using System.Threading.Tasks;
using EasyLab.Core.Dto.GatewayResponses;
using EasyLab.Core.Dto.UseCaseRequests.Student;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Entities;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.Services;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Student;

namespace EasyLab.Core.UseCases.Student
{
    public class BuildProjectHandler : IBuildProjectHandler
    {

        private readonly IProjectFactory _projectFactory;

        private readonly IAssignmentRepository _assignmentRepository;

        private readonly ICourseUserRepository _courseUsersRepository;

        private readonly IProjectRepository _projectRepository;

        private readonly IUserRepository _userRepository;

        public BuildProjectHandler(IProjectFactory projectFactory, IAssignmentRepository assignmentRepository, ICourseUserRepository courseUsersRepository, IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectFactory = projectFactory;
            _assignmentRepository = assignmentRepository;
            _courseUsersRepository = courseUsersRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(BuildProjectRequest request, IOutputPort<BasicResponse> outputPort)
        {
            User user = await _userRepository.GetById<Guid>(request.UserId);
            BashResponse bashResponse = await _projectFactory.BuildProject(user.UserName, request.ProjectId.ToString());
            outputPort.Handle(new BasicResponse(true, bashResponse.success? bashResponse.Output:bashResponse.Error));
        }
    }
}

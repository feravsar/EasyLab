using System;
using System.Threading.Tasks;
using EasyLab.Core.Dto.GatewayResponses;
using EasyLab.Core.Dto.UseCaseRequests.Student;
using EasyLab.Core.Dto.UseCaseResponses.Student;
using EasyLab.Core.Entities;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.Services;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Student;

namespace EasyLab.Core.UseCases.Student
{
    public class UpdateDocumentHandler : IUpdateDocumentHandler
    {

        private readonly IProjectFactory _projectFactory;

        private readonly IAssignmentRepository _assignmentRepository;

        private readonly ICourseUserRepository _courseUsersRepository;

        private readonly IProjectRepository _projectRepository;

        private readonly IUserRepository _userRepository;

        public UpdateDocumentHandler(IProjectFactory projectFactory, IAssignmentRepository assignmentRepository, ICourseUserRepository courseUsersRepository, IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectFactory = projectFactory;
            _assignmentRepository = assignmentRepository;
            _courseUsersRepository = courseUsersRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }
        public async Task Handle(UpdateDocumentRequest request, IOutputPort<UpdateDocumentResponse> outputPort)
        {
            User user = await _userRepository.GetById<Guid>(request.UserId);
            BashResponse bashResponse = await _projectFactory.UpdateDocument(user.UserName, request.ProjectId.ToString(), request.FileName, request.FileContent);
            outputPort.Handle(new UpdateDocumentResponse(bashResponse));
    
        }
    }
}

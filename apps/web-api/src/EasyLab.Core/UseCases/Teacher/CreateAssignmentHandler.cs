using System;
using System.Threading.Tasks;

using EasyLab.Core.Dto.UseCaseRequests.Teacher;
using EasyLab.Core.Dto.UseCaseResponses.Teacher;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Teacher;

namespace EasyLab.Core.UseCases.Teacher{
    public sealed class CreateAssignmentHandler : ICreateAssignmentHandler
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IAssignmentRepository _assignmentRepository;

        public CreateAssignmentHandler(ICourseRepository courseRepository, IAssignmentRepository assignmentRepository)
        {
            _courseRepository = courseRepository;
            _assignmentRepository = assignmentRepository;
        }

        public async Task Handle(CreateAssignmentRequest request, IOutputPort<CreateAssignmentResponse> outputPort)
        {
            
            if (!(await _courseRepository.IsAuthoredAsTeacher(request.UserId, request.CourseId)))
                throw new Exception("You're not authorized for this action");

           var entity = await _assignmentRepository.Add(new Entities.Assignment{
                AuthorId = request.UserId,
                CourseId = request.CourseId,
                DateCreated = DateTime.UtcNow,
                Description = request.Description,
                Title = request.Title,
                LanguageId = 1,
                TestCase = null,
                Due = request.Due.ToUniversalTime(),
            });

            outputPort.Handle(new CreateAssignmentResponse(entity.Id));

        }
    }
}
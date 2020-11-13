using System;
using System.Linq;
using System.Threading.Tasks;

using EasyLab.Core.Dto.UseCaseRequests.Teacher;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Teacher;
using EasyLab.Core.Specifications;

namespace EasyLab.Core.UseCases.Teacher
{
    public sealed class AddMemberHandler : IAddMemberHandler
    {
        private readonly ICourseRepository _courseRepository;

        public AddMemberHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task Handle(AddMemberRequest request, IOutputPort<BasicResponse> outputPort)
        {
            var course = await _courseRepository.GetCourseWithUsers(request.CourseId);

            //Only author of the course can add an instructor.
            if (request.IsInstructor)
            {
                if (course.AuthorId != request.AuthorId)
                    throw new Exception("You're not authorized for this operation.");
            }
            //Author of the course and other instructors can add students.
            else
            {
                if (course.AuthorId != request.AuthorId && !course.Users.Any(t => t.UserId == request.AuthorId && t.IsInstructor))
                    throw new Exception("You're not authorized for this operation.");
            }

            course.Users.Add(new Entities.CourseUser
            {
                IsInstructor = request.IsInstructor,
                UserId = request.UserId
            });

            await _courseRepository.Save();

            outputPort.Handle(new BasicResponse(true, "User added successfully"));
        }
    }
}
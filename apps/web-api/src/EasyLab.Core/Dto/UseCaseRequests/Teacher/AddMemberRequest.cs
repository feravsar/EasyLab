using System;

using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Teacher
{
    public class AddMemberRequest : IUseCaseRequest<BasicResponse>
    {
        public AddMemberRequest(Guid authorId, Guid userId, Guid courseId, bool isInstructor)
        {
            AuthorId = authorId;
            UserId = userId;
            CourseId = courseId;
            DateAdded = DateTime.UtcNow;
            IsInstructor = isInstructor;
        }

        public Guid AuthorId { get; }
        public Guid UserId { get; }
        public Guid CourseId { get; }
        public DateTime DateAdded {get;}

        public bool IsInstructor {get;}

    }
}
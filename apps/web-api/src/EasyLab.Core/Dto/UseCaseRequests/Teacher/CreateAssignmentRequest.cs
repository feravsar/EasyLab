using System;

using EasyLab.Core.Dto.UseCaseResponses.Teacher;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Teacher
{
    public class CreateAssignmentRequest : IUseCaseRequest<CreateAssignmentResponse>
    {
        public CreateAssignmentRequest(Guid courseId, Guid userId, DateTime due, string description, int languageId, string title)
        {
            CourseId = courseId;
            UserId = userId;
            Due = due;
            Description = description;
            LanguageId = languageId;
            Title = title;
        }

        public Guid CourseId { get; private set; }

        public Guid UserId { get; private set; }

        public DateTime Due { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public int LanguageId { get; private set; }

    }
}
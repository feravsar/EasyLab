using System;

using EasyLab.Core.Dto.UseCaseResponses.Teacher;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests.Teacher
{
    public class AddCourseRequest : IUseCaseRequest<AddCourseResponse>
    {
        public string Name { get; }
        public string Description { get; }
        public Guid AuthorId { get; }
        public DateTime DateCreated {get;}

        public AddCourseRequest(string name, string description, Guid authorId)
        {
            Name = name;
            Description = description;
            AuthorId = authorId;
            DateCreated = DateTime.UtcNow;
        }
    }
}

using System;

namespace EasyLab.Core.Dto.Entity{
    public class AssignmentDto
    {
        public AssignmentDto(Guid id, string author, DateTime due, DateTime dateCreated, string title, string description, string language)
        {
            Id = id;
            Author = author;
            Due = due;
            DateCreated = dateCreated;
            Title = title;
            Description = description;
            Language = language;
        }

        public AssignmentDto(Guid id, string author, DateTime due, DateTime dateCreated, string title, string description, string language, ProjectDto project) : this(id, author, due, dateCreated, title, description, language)
        {
            Project = project;
        }

        public Guid Id { get; private set; }

        public string Author { get; private set; }

        public DateTime Due { get; private set; }

        public DateTime DateCreated { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Language { get; private set; }

        public ProjectDto Project { get; private set; }

    }
}
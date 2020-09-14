using System;

namespace EasyLab.Core.Dto.Course
{
    public class CourseUserInfo
    {
        public CourseUserInfo(Guid userId, string name, string surname, string email, Guid courseId, bool isInstructor, DateTime dateAdded)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
            CourseId = courseId;
            IsInstructor = isInstructor;
            DateAdded = dateAdded;
        }

        public Guid UserId { get; }

        public string Name { get; }
        public string Surname { get; }

        public string Email { get; }

        public Guid CourseId { get; }

        public bool IsInstructor { get; }

        public DateTime DateAdded { get; }

    }
}
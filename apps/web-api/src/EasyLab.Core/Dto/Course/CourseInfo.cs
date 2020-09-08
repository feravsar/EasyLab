using System;

namespace EasyLab.Core.Dto.Course{
    public class CourseInfo
    {
        public CourseInfo(Guid id, string name, string description, DateTime dateCreated, int studentsEnrolled)
        {
            Id = id;
            Name = name;
            Description = description;
            DateCreated = dateCreated;
            StudentsEnrolled = studentsEnrolled;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; } 

        public string Description { get; private set; }

        public DateTime DateCreated { get; private set; }

        public int StudentsEnrolled { get; private set; }
    }
}
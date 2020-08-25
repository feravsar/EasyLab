using System;

namespace EasyLab.Core.Entities
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }
        
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
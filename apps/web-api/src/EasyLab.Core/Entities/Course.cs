using System;
using System.Collections.Generic;

namespace EasyLab.Core.Entities
{
    public class Course
    {
        public Course(){
            Assignments = new List<Assignment>();
            Users = new List<CourseUser>();
            DateCreated = DateTime.UtcNow;
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid AuthorId { get; set; }


        public virtual User Author { get; set; }

        public virtual List<Assignment> Assignments { get; set; }

        public virtual List<CourseUser> Users { get; set; }
    }
}
using System;

namespace EasyLab.Core.Entities
{
    public class CourseUsers
    {
        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public bool IsInstructor { get; set; }

        public DateTime DateAdded { get; set; }


        public virtual User User {get;set;}
        public virtual Course Course { get; set; }
    }
}
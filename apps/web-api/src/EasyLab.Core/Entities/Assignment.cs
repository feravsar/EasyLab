using System;
using System.Collections.Generic;

namespace EasyLab.Core.Entities
{
    public class Assignment
    {
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public Guid AuthorId { get; set; }

        public DateTime Due { get; set; }

        public DateTime DateCreated { get; set; }

        public string Description { get; set; }

        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string TestCase { get; set; }


        public virtual User Author { get; set; }

        public virtual Course Course { get; set; }

        public virtual Language Language { get; set; }

        public virtual List<StudentAssignments> StudentAssignments { get; set; }
    }
}
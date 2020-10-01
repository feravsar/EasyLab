using System;

namespace EasyLab.Core.Entities
{
    public class Project
    {

        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }

        public Guid AssignmentId { get; set; }


        public DateTime DateFinished { get; set; }

        public DateTime DateStarted { get; set; }

        public double? Grade { get; set; }


        public virtual User User { get; set; }

        public virtual Assignment Assignment { get; set; }
    }
}
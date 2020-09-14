using System;

namespace EasyLab.Core.Entities
{
    public class StudentAssignments
    {
        public Guid UserId { get; set; }

        public Guid AssignmentId { get; set; }

        public DateTime DateFinished { get; set; }

        public double? Grade { get; set; }


        public virtual User User { get; set; }

        public virtual Assignment Assignment { get; set; }
    }
}
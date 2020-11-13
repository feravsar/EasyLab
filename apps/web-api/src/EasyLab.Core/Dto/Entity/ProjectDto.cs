using System;

namespace EasyLab.Core.Dto.Entity
{
    public class ProjectDto 
    {
        public ProjectDto(Guid projectId, DateTime dateStarted, DateTime dateFinished, double? grade)
        {
            ProjectId = projectId;
            DateStarted = dateStarted;
            DateFinished = dateFinished;
            Grade = grade;
        }

        public Guid ProjectId { get; private set; }

        public DateTime DateStarted { get; private set; }

        public DateTime DateFinished { get; private set; }

        public double? Grade { get; private set; }


    }
}

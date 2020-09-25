using System;
using System.Threading.Tasks;

using EasyLab.Core.Entities;

namespace EasyLab.Core.Interfaces.Gateways.Repositories
{
    public interface IStudentAssignmentsRepository : IEfRepository<StudentAssignments>
    {
        Task<bool> IsProjectStarted(Guid assignmentId, Guid userId);
    }
}

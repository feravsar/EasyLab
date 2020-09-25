using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using EasyLab.Core.Entities;
using EasyLab.Core.Interfaces.Gateways.Repositories;

namespace EasyLab.Infrastructure.Data.Repositories
{
    public class StudentAssignmentsRepository : EfRepository<StudentAssignments>, IStudentAssignmentsRepository
    {
        public StudentAssignmentsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsProjectStarted(Guid assignmentId, Guid userId)
        {
            return await Queryable()
            .AnyAsync(t=>t.AssignmentId == assignmentId && t.UserId == userId);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Entities;

namespace EasyLab.Core.Interfaces.Gateways.Repositories
{
    public interface IAssignmentRepository : IEfRepository<Assignment>
    {
      Task<List<AssignmentDto>> GetAssignments(Guid courseId);
      Task<List<AssignmentDto>> GetProjects(Guid courseId, Guid userId);
    }
}
using System;
using System.Threading.Tasks;

using EasyLab.Core.Entities;

namespace EasyLab.Core.Interfaces.Gateways.Repositories
{
    public interface IProjectRepository : IEfRepository<Project>
    {
        Task<bool> IsProjectStarted(Guid assignmentId, Guid userId);
    }
}

using System.Threading.Tasks;
using EasyLab.Core.Dto.GatewayResponses;

namespace EasyLab.Core.Interfaces.Services
{
    public interface IProjectFactory
    {
        Task<BashResponse> CreateProject(string courseId, string assignmentId, string userId);

        Task<BashResponse> CreateUser(string username);
    }
}
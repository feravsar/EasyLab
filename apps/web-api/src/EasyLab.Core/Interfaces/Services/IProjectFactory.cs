using System.Threading.Tasks;
using EasyLab.Core.Dto.GatewayResponses;

namespace EasyLab.Core.Interfaces.Services
{
    public interface IProjectFactory
    {
        Task<BashResponse> BuildProject(string username, string projectId);
        Task<BashResponse> RunProject(string username, string projectId);
        Task<BashResponse> CreateProject(string username, string projectId);
        Task<BashResponse> GetFileContent(string username, string projectId, string fileName);
        Task<BashResponse> CreateUser(string username);
        Task<BashResponse> UpdateDocument(string username, string projectId, string fileName, string fileContent);
    }
}
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using EasyLab.Core.Dto.GatewayResponses;
using EasyLab.Core.Interfaces.Services;

namespace EasyLab.Infrastructure.Project
{
    public sealed class ProjectFactory : IProjectFactory
    {
        public async Task<BashResponse> CreateProject(string courseId, string assignmentId, string userId)
        {
            var dirPath = Assembly.GetExecutingAssembly().Location;
            dirPath = Path.GetDirectoryName(dirPath);
            var finalPath = Path.Combine(dirPath, "Scripts/create_java_project.sh " + courseId + " " + assignmentId +" " + userId);
            return await finalPath.Bash();
        }
    }
}
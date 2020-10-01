using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using EasyLab.Core.Dto.GatewayResponses;
using EasyLab.Core.Interfaces.Services;

namespace EasyLab.Infrastructure.Project
{
    public sealed class ProjectFactory : IProjectFactory
    {

        string dirPath;

        public ProjectFactory()
        {
            this.dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public async Task<BashResponse> CreateProject(string courseId, string assignmentId, string userId)
        {
            var finalPath = Path.Combine(dirPath, "Scripts/create_java_project.sh " + courseId + " " + assignmentId + " " + userId);
            return await finalPath.Bash();
        }

        public async Task<BashResponse> CreateUser(string username)
        {
             var finalPath = Path.Combine(dirPath, "Scripts/user_scripts.sh " + username);
             return await finalPath.Bash();
        }
    }
}
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

        public async Task<BashResponse> CreateProject(string username, string projectId)
        {
            var finalPath = Path.Combine("sudo -u " + username + " /bin/bash " + dirPath, "Scripts/create_java_project.sh " + username + " " + projectId);
            return await finalPath.Bash();
        }

        public async Task<BashResponse> BuildProject(string username, string projectId)
        {
            var finalPath = Path.Combine("sudo -u " + username + " /bin/bash " + dirPath, "Scripts/build_java_project.sh " + username + " " + projectId);
            return await finalPath.Bash();
        }

        public async Task<BashResponse> RunProject(string username, string projectId)
        {
            var finalPath = Path.Combine("sudo -u " + username + " /bin/bash " + dirPath, "Scripts/run_java_project.sh " + username + " " + projectId);
            return await finalPath.Bash();
        }
         public async Task<BashResponse> GetFileContent(string username, string projectId, string fileName)
        {
            var finalPath = Path.Combine("sudo -u " + username + " /bin/bash " + dirPath, "Scripts/read_file.sh " + username + " " + projectId + " " + fileName);
            return await finalPath.Bash();
        }

        public async Task<BashResponse> UpdateDocument(string username, string projectId, string fileName, string fileContent)
        {
            var finalPath = Path.Combine("sudo -u " + username + " /bin/bash " + dirPath, "Scripts/update_document.sh " + username + " " + projectId + " " + fileName + " " + fileContent);
            return await finalPath.Bash();
        }

        public async Task<BashResponse> CreateUser(string username)
        {
            var finalPath = Path.Combine(dirPath, "Scripts/user_scripts.sh " + username);
            return await finalPath.Bash();
        }
    }
}
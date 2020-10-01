using System.Collections.Generic;
using System.Threading.Tasks;
using EasyLab.Core.Dto.Auth;

namespace EasyLab.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName, List<string> userRoles);
    }
}

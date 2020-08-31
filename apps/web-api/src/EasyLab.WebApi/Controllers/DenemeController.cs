using System.Linq;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases.User;
using EasyLab.WebApi.Models.Settings;
using EasyLab.WebApi.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EasyLab.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        [Authorize]
        [HttpPost("DenemePost")]
        public async Task<ActionResult> DenemePost([FromBody] Models.Request.LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var x =User.Claims.FirstOrDefault(t=>t.Type=="id").Value;
           

            return null;
        }


    }
}

using System.Linq;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases.Course;
using EasyLab.Core.Interfaces.UseCases.Teacher;
using EasyLab.Core.Interfaces.UseCases.User;
using EasyLab.WebApi.Models.Settings;
using EasyLab.WebApi.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EasyLab.WebApi.Controllers
{
    [Route("T")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IGetAuthoredCoursesHandler _getAuthoredCoursesHandler;
        private readonly BasePresenter _basePresenter;

        public TeacherController(
            IGetAuthoredCoursesHandler getAuthoredCoursesHandler,
            BasePresenter basePresenter)
        {
            _getAuthoredCoursesHandler = getAuthoredCoursesHandler;
            _basePresenter = basePresenter;
        }

        [Authorize]
        [HttpGet("Courses")]
        public async Task<ActionResult> Courses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;
            await _getAuthoredCoursesHandler.Handle(
                new GetAuthoredCoursesRequest(new System.Guid(userId)),
                _basePresenter);
            
            return _basePresenter.ContentResult;

        }

    }
}

using System.Linq;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases.Course;
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
    public class CourseController : ControllerBase
    {
        private readonly IAddCourseHandler _addCourseHandler;
        private readonly BasePresenter _basePresenter;

        public CourseController(
            IAddCourseHandler addCourseHandler,
            BasePresenter basePresenter)
        {
            _addCourseHandler = addCourseHandler;
            _basePresenter = basePresenter;
        }

        [Authorize]
        [HttpPost("AddCourse")]
        public async Task<ActionResult> AddCourse([FromBody] Models.Request.AddCourseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;
            await _addCourseHandler.Handle(
                new AddCourseRequest(request.Name,request.Description,new System.Guid(userId)),
                _basePresenter);
            
            return _basePresenter.ContentResult;

        }

    }
}

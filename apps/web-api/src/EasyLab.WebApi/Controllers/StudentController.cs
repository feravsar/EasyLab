using System;
using System.Linq;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Interfaces.UseCases.Student;
using EasyLab.WebApi.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyLab.WebApi.Controllers
{
    [Route("S")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGetEnrolledCoursesHandler _getEnrolledCoursesHandler;

        private readonly IStartProjectHandler _startProjectHandler;
        private readonly BasePresenter _basePresenter;

        public StudentController(IGetEnrolledCoursesHandler getEnrolledCoursesHandler, IStartProjectHandler startProjectHandler, BasePresenter basePresenter)
        {
            _getEnrolledCoursesHandler = getEnrolledCoursesHandler;
            _startProjectHandler = startProjectHandler;
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
            await _getEnrolledCoursesHandler.Handle(
                new GetEnrolledCoursesRequest(new System.Guid(userId)),
                _basePresenter);

            return _basePresenter.ContentResult;
        }


        
        [HttpPost("StartProject")]
        public async Task<ActionResult> StartProject(Models.Request.StartProjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;
            
            await _startProjectHandler.Handle(
                new StartProjectRequest(request.AssignmentId,new Guid(userId)),
                _basePresenter);

            return _basePresenter.ContentResult;
        }
    }
}

using System;
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
        private readonly ICreateAssignmentHandler _createAssignmentHandler;
        private readonly IGetAssignmentsHandler _getAssignmentsHandler;
        private readonly BasePresenter _basePresenter;


        public CourseController(IAddCourseHandler addCourseHandler, ICreateAssignmentHandler createAssignmentHandler, IGetAssignmentsHandler getAssignmentsHandler, BasePresenter basePresenter)
        {
            _addCourseHandler = addCourseHandler;
            _createAssignmentHandler = createAssignmentHandler;
            _getAssignmentsHandler = getAssignmentsHandler;
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


        [Authorize]
        [HttpPost("CreateAssignment")]
        public async Task<ActionResult> CreateAssignment([FromBody] Models.Request.CreateAssignmentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _createAssignmentHandler.Handle(
                new CreateAssignmentRequest(request.CourseId,new System.Guid(userId),request.Due,request.Description,request.LanguageId,request.Title),
                _basePresenter);
            
            return _basePresenter.ContentResult;

        }

        [Authorize]
        [HttpGet("Assignments")]
        public async Task<ActionResult> Assignments(Guid courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _getAssignmentsHandler.Handle(
                new GetAssignmentsRequest(new Guid(userId),courseId),
                _basePresenter);
            
            return _basePresenter.ContentResult;

        }
    }
}

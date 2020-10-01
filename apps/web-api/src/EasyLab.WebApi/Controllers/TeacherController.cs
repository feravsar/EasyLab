using System;
using System.Linq;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests.Teacher;
using EasyLab.Core.Interfaces.UseCases.Teacher;
using EasyLab.WebApi.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyLab.WebApi.Controllers
{
    [Route("T")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IGetAuthoredCoursesHandler _getAuthoredCoursesHandler;
        private readonly IAddMemberHandler _addMemberHandler;

        private readonly IGetMembersHandler _getMembersHandler;
        private readonly BasePresenter _basePresenter;

        public TeacherController(IGetAuthoredCoursesHandler getAuthoredCoursesHandler, IAddMemberHandler addMemberHandler, IGetMembersHandler getMembersHandler, BasePresenter basePresenter)
        {
            _getAuthoredCoursesHandler = getAuthoredCoursesHandler;
            _addMemberHandler = addMemberHandler;
            _getMembersHandler = getMembersHandler;
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

        [Authorize]
        [HttpPost("AddMember")]
        public async Task<ActionResult> AddMember(Models.Request.AddMemberRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;
            await _addMemberHandler.Handle(
                new AddMemberRequest(new Guid(userId),request.UserId,request.CourseId,request.IsInstructor),
                _basePresenter);

            return _basePresenter.ContentResult;
        }

        [Authorize]
        [HttpGet("GetMembers")]
        public async Task<ActionResult> GetMembers(Guid courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _getMembersHandler.Handle(new GetMembersRequest(new Guid(userId),courseId),_basePresenter);
            
            return _basePresenter.ContentResult;
        }

    }
}

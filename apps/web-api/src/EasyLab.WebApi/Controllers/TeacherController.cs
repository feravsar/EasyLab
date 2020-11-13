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
    
    [Authorize(Roles = "TEACHER")]
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IGetAuthoredCoursesHandler _getAuthoredCoursesHandler;
        private readonly IAddMemberHandler _addMemberHandler;
        private readonly ISearchUserHandler _searchUserHandler;
        private readonly IGetMembersHandler _getMembersHandler;
        private readonly IAddCourseHandler _addCourseHandler;
        private readonly ICreateAssignmentHandler _createAssignmentHandler;
        private readonly IGetAssignmentsHandler _getAssignmentsHandler;
        private readonly BasePresenter _basePresenter;

        public TeacherController(IGetAuthoredCoursesHandler getAuthoredCoursesHandler, IAddMemberHandler addMemberHandler, IGetMembersHandler getMembersHandler, IAddCourseHandler addCourseHandler, ICreateAssignmentHandler createAssignmentHandler, IGetAssignmentsHandler getAssignmentsHandler, BasePresenter basePresenter, ISearchUserHandler searchUserHandler)
        {
            _getAuthoredCoursesHandler = getAuthoredCoursesHandler;
            _addMemberHandler = addMemberHandler;
            _getMembersHandler = getMembersHandler;
            _addCourseHandler = addCourseHandler;
            _createAssignmentHandler = createAssignmentHandler;
            _getAssignmentsHandler = getAssignmentsHandler;
            _basePresenter = basePresenter;
            _searchUserHandler = searchUserHandler;
        }

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

        [HttpPost("AddMember")]
        public async Task<ActionResult> AddMember(Models.Request.AddMemberRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;
            await _addMemberHandler.Handle(
                new AddMemberRequest(new Guid(userId), request.UserId, request.CourseId, request.IsInstructor),
                _basePresenter);

            return _basePresenter.ContentResult;
        }

       
        [HttpGet("GetMembers")]
        public async Task<ActionResult> GetMembers(Guid courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _getMembersHandler.Handle(new GetMembersRequest(new Guid(userId), courseId), _basePresenter);

            return _basePresenter.ContentResult;
        }

        [HttpPost("AddCourse")]
        public async Task<ActionResult> AddCourse([FromBody] Models.Request.AddCourseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;
            await _addCourseHandler.Handle(
                new AddCourseRequest(request.Name, request.Description, new System.Guid(userId)),
                _basePresenter);

            return _basePresenter.ContentResult;

        }


        [HttpPost("CreateAssignment")]
        public async Task<ActionResult> CreateAssignment([FromBody] Models.Request.CreateAssignmentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _createAssignmentHandler.Handle(
                new CreateAssignmentRequest(request.CourseId, new System.Guid(userId), request.Due, request.Description, request.LanguageId, request.Title),
                _basePresenter);

            return _basePresenter.ContentResult;

        }

        [HttpGet("Assignments")]
        public async Task<ActionResult> Assignments(Guid courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _getAssignmentsHandler.Handle(
                new GetAssignmentsRequest(new Guid(userId), courseId),
                _basePresenter);

            return _basePresenter.ContentResult;

        }

        [HttpGet("SearchUser")]
        public async Task<ActionResult> SearchUser(string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 3)
            {
                return BadRequest(ModelState);
            }
            await _searchUserHandler.Handle(
                new SearchUserRequest(
                   searchTerm),
                _basePresenter);

            return _basePresenter.ContentResult;
        }


    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests.Student;
using EasyLab.Core.Interfaces.UseCases.Student;
using EasyLab.WebApi.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyLab.WebApi.Controllers
{
    [Authorize(Roles = "STUDENT")]
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGetEnrolledCoursesHandler _getEnrolledCoursesHandler;
        private readonly IGetProjectsHandler _getProjectsHandler;
        private readonly IStartProjectHandler _startProjectHandler;
        private readonly IGetFileContentHandler _getFileContentHandler;
        private readonly IBuildProjectHandler _buildProjectHandler;
        private readonly IUpdateDocumentHandler _updateDocumentHandler;
        private readonly IRunProjectHandler _runProjectHandler;
        private readonly BasePresenter _basePresenter;


        public StudentController(IGetEnrolledCoursesHandler getEnrolledCoursesHandler, IGetProjectsHandler getProjectsHandler, IStartProjectHandler startProjectHandler, BasePresenter basePresenter, IBuildProjectHandler buildProjectHandler, IGetFileContentHandler getFileContentHandler, IRunProjectHandler runProjectHandler, IUpdateDocumentHandler updateDocumentHandler)
        {
            _getEnrolledCoursesHandler = getEnrolledCoursesHandler;
            _getProjectsHandler = getProjectsHandler;
            _startProjectHandler = startProjectHandler;
            _basePresenter = basePresenter;
            _buildProjectHandler = buildProjectHandler;
            _getFileContentHandler = getFileContentHandler;
            _runProjectHandler = runProjectHandler;
            _updateDocumentHandler = updateDocumentHandler;
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
                new StartProjectRequest(request.AssignmentId, new Guid(userId)),
                _basePresenter);

            return _basePresenter.ContentResult;
        }

        [HttpPost("BuildProject")]
        public async Task<ActionResult> BuildProject(Models.Request.BuildProjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _buildProjectHandler.Handle(
                new BuildProjectRequest(request.ProjectId, new Guid(userId)),
                _basePresenter);

            return _basePresenter.ContentResult;
        }


        [Authorize]
        [HttpGet("GetProjects")]
        public async Task<ActionResult> GetProjects(Guid courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _getProjectsHandler.Handle(
                new GetProjectsRequest(new Guid(userId), courseId),
                _basePresenter);

            return _basePresenter.ContentResult;
        }

        [Authorize]
        [HttpGet("GetFileContent")]
        public async Task<ActionResult> GetFileContent(Guid projectId, string fileName = "App.java")
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _getFileContentHandler.Handle(
                new GetFileContentRequest(new Guid(userId), projectId, fileName),
                _basePresenter);

            return _basePresenter.ContentResult;
        }

        [Authorize]
        [HttpPost("RunProject")]
        public async Task<ActionResult> RunProject(Models.Request.RunProjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _runProjectHandler.Handle(
                new RunProjectRequest(request.ProjectId, new Guid(userId)),
                _basePresenter);

            return _basePresenter.ContentResult;
        }

        [Authorize]
        [HttpPost("UpdateDocument")]
        public async Task<ActionResult> UpdateDocument(Models.Request.UpdateDocumentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(t => t.Type == "id")?.Value;

            await _updateDocumentHandler.Handle(
                new UpdateDocumentRequest(new Guid(userId),request.ProjectId,request.FileName, request.FileContent),
                _basePresenter);

            return _basePresenter.ContentResult;
        }
    }
}

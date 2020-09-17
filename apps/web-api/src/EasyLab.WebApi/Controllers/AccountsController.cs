using System;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases.User;
using EasyLab.WebApi.Presenters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyLab.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        //Registering user
        private readonly IRegisterUserHandler _registerUserHandler;
        private readonly ISearchUserHandler _searchUserHandler;
        private readonly BasePresenter _basePresenter;


        public AccountsController(
            IRegisterUserHandler registerUserHandler,
            ISearchUserHandler searchUserHandler,
            BasePresenter basePresenter
           )
        {
            _registerUserHandler = registerUserHandler;
            _searchUserHandler = searchUserHandler;
            _basePresenter = basePresenter;
        }

      
        [HttpPost("Register")]
        [ProducesResponseType(typeof(RegisterUserResponse),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RegisterUserResponse),StatusCodes.Status201Created)]
        
        public async Task<ActionResult> Register([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             await _registerUserHandler.Handle(
                 new RegisterUserRequest(
                    request.Name, 
                    request.Surname, 
                    request.Email, 
                    request.Password),
                 _basePresenter);

            return _basePresenter.ContentResult;
        }

        
        [HttpGet("SearchUser")]
        public async Task<ActionResult> SearchUser(string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length<3)
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
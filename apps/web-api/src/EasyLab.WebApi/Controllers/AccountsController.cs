using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EasyLab.Core.Dto.UseCaseRequests.Account;
using EasyLab.Core.Dto.UseCaseRequests.Teacher;
using EasyLab.Core.Dto.UseCaseResponses.Account;
using EasyLab.Core.Interfaces.UseCases.Account;
using EasyLab.Core.Interfaces.UseCases.Teacher;
using EasyLab.WebApi.Presenters;

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
        [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status201Created)]

        public async Task<ActionResult> Register([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _registerUserHandler.Handle(
                new RegisterUserRequest(
                    request.Username,
                   request.Name,
                   request.Surname,
                   request.Email,
                   request.Password),
                _basePresenter);

            return _basePresenter.ContentResult;
        }


        
    }
}
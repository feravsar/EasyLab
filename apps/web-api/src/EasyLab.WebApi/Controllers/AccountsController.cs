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
        private readonly BasePresenter _basePresenter;


        public AccountsController(
            IRegisterUserHandler registerUserHandler,
            BasePresenter basePresenter
           )
        {
            _registerUserHandler = registerUserHandler;
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
    }
}
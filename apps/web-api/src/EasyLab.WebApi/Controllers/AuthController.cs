using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using EasyLab.Core.Dto.UseCaseRequests.Auth;
using EasyLab.Core.Dto.UseCaseResponses.Auth;
using EasyLab.Core.Interfaces.UseCases.Auth;
using EasyLab.WebApi.Models.Settings;
using EasyLab.WebApi.Presenters;

namespace EasyLab.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Log in user
        private readonly IUserLoginHandler _userLoginHandler;
        private readonly BasePresenter _basePresenter;
        private readonly IExchangeRefreshTokenHandler _exchangeRefreshTokenHandler;
        private readonly AuthSettings _authSettings;

        public AuthController(
            IUserLoginHandler userLoginHandler,
            IExchangeRefreshTokenHandler exchangeRefreshTokenHandler,
            BasePresenter basePresenter,
            IOptions<AuthSettings> authSettings)
        {
            _userLoginHandler = userLoginHandler;
            _exchangeRefreshTokenHandler = exchangeRefreshTokenHandler;
            _basePresenter = basePresenter;
            _authSettings = authSettings.Value;
        }



        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] Models.Request.LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userLoginHandler.Handle(
                new UserLoginRequest(request.Username, request.Password, Request.HttpContext.Connection.RemoteIpAddress?.ToString()), 
                _basePresenter);

            return _basePresenter.ContentResult;
        }



        /// <summary>
        /// This method should be used when the API responded with the header Token-Expired. 
        /// If method returns Bad Request, according to error message, parameters should be checked or user should logged in again
        /// </summary>
        [Microsoft.AspNetCore.Authorization.Authorize]
        [HttpPost("RefreshToken")]
        [ProducesResponseType(typeof(ExchangeRefreshTokenResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ExchangeRefreshTokenResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] Models.Request.ExchangeRefreshTokenRequest request)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState); 
            }
            await _exchangeRefreshTokenHandler.Handle(
                new ExchangeRefreshTokenRequest(request.AccessToken, request.RefreshToken, _authSettings.SecretKey), 
                _basePresenter);
            
            return _basePresenter.ContentResult;
        }
    }
}

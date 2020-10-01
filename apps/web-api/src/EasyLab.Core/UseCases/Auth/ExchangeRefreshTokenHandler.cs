using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyLab.Core.Dto;
using EasyLab.Core.Dto.UseCaseRequests.Auth;
using EasyLab.Core.Dto.UseCaseResponses.Auth;
using EasyLab.Core.Entities;
using EasyLab.Core.Helpers.Exceptions;
using EasyLab.Core.Helpers.Exceptions.User;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.Services;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Auth;
using EasyLab.Core.Specifications;

namespace EasyLab.Core.UseCases.Auth
{
    public sealed class ExchangeRefreshTokenHandler : IExchangeRefreshTokenHandler
    {
        private readonly IJwtTokenValidator _jwtTokenValidator;

        private readonly IUserRepository _userRepository;

        private readonly IJwtFactory _jwtFactory;

        private readonly ITokenFactory _tokenFactory;

        public ExchangeRefreshTokenHandler(
            IJwtTokenValidator jwtTokenValidator,
            IUserRepository userRepository,
            IJwtFactory jwtFactory,
            ITokenFactory tokenFactory)
        {
            _jwtTokenValidator = jwtTokenValidator;
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
        }

        public async Task Handle(ExchangeRefreshTokenRequest message, IOutputPort<ExchangeRefreshTokenResponse> outputPort)
        {
            ExchangeRefreshTokenResponse response = null;
            try
            {
                //Getting user claims from token
                ClaimsPrincipal claimsPrincipal = _jwtTokenValidator.GetPrincipalFromToken(message.AccessToken, message.SigningKey);
                // invalid token/signing key was passed and we can't extract user claims
                if (claimsPrincipal == null)
                    throw new InvalidAccessTokenException();

                //Getting user from repository
                Claim id = claimsPrincipal.Claims.First(c => c.Type == "id");
                
                Entities.User user = await _userRepository.GetSingleBySpec(new UserSpecification(new Guid(id.Value)));


                if (!user.HasValidRefreshToken(message.RefreshToken))
                    throw new InvalidRefreshTokenException();

                //generating new access token
                var jwtToken = await _jwtFactory.GenerateEncodedToken(user.Id.ToString(), user.UserName);
                //generating new refresh token
                var refreshToken = _tokenFactory.GenerateToken();

                // delete the refresh token that exchanged
                user.RemoveRefreshToken(message.RefreshToken);
                // add the new one
                user.AddRefreshToken(refreshToken, user.Id, ""); 
                await _userRepository.Update(user);

                response = new ExchangeRefreshTokenResponse(jwtToken, refreshToken);
            }
            catch (EasyLabException ex)
            {
                response = new ExchangeRefreshTokenResponse(new List<Error>() { new Error(ex.Code, ex.Message) });
            }
            catch (Exception ex)
            {
                response = new ExchangeRefreshTokenResponse(new List<Error>() { new Error(ex.GetType().Name, ex.Message) });
            }
            finally
            {
                outputPort.Handle(response);
            }

        }
    }
}
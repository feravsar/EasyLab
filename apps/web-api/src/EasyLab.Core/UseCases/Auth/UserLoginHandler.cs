using System.Collections.Generic;
using System.Threading.Tasks;
using EasyLab.Core.Dto;
using EasyLab.Core.Dto.Auth;
using EasyLab.Core.Dto.UseCaseRequests.Auth;
using EasyLab.Core.Dto.UseCaseResponses.Auth;
using EasyLab.Core.Helpers.Exceptions;
using EasyLab.Core.Helpers.Exceptions.User;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.Services;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Auth;

namespace EasyLab.Core.UseCases.Auth
{
    public class UserLoginHandler : IUserLoginHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;

        public UserLoginHandler(IUserRepository userRepository, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
        }

        public async Task Handle(UserLoginRequest request, IOutputPort<UserLoginResponse> outputPort)
        {
            UserLoginResponse response = null;
            try
            {
                //Getting user from repository
                Entities.User user = await _userRepository.FindByName(request.Email);
                //if user doesn't exist
                if (user == null)
                    throw new UserNotFoundException(request.Email);

                if (!user.EmailConfirmed)
                    //throw new EmailNotVerifiedException(user.Email);

                //if user and password matches
                if (!(await _userRepository.CheckPassword(user, request.Password)))
                    throw new UsernameOrPasswordWrongException();

                List<string> roles = await _userRepository.GetUserRoles(user) as List<string>;

                //generating refresh token
                string refreshToken = _tokenFactory.GenerateToken();
                user.AddRefreshToken(refreshToken, user.Id, request.RemoteIpAddress);
                await _userRepository.Update(user);

                //generating access token
                AccessToken accessToken = await _jwtFactory.GenerateEncodedToken(user.Id.ToString(), user.UserName, roles);

                //return tokens
                response = new UserLoginResponse(accessToken, refreshToken, user.Name, user.Surname, roles);

            }
            catch (EasyLabException ex)
            {
                response = new UserLoginResponse(new List<Error>() { new Error(ex.Code, ex.Message) });
            }
            catch (System.Exception ex)
            {
                response = new UserLoginResponse(new List<Error>() { new Error(ex.GetType().Name, ex.Message) });
            }
            finally
            {
                outputPort.Handle(response);
            }


        }
    }
}
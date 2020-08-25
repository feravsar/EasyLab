using System.Collections.Generic;
using System.Threading.Tasks;
using EasyLab.Core.Dto;
using EasyLab.Core.Dto.Auth;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Helpers.Exceptions;
using EasyLab.Core.Helpers.Exceptions.User;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.Services;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.User;

namespace EasyLab.Core.UseCases.User
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
                    throw new EmailNotVerifiedException(user.Email);

                //if user and password matches
                if (!(await _userRepository.CheckPassword(user, request.Password)))
                    throw new UsernameOrPasswordWrongException();


                //generating refresh token
                string refreshToken = _tokenFactory.GenerateToken();
                user.AddRefreshToken(refreshToken, user.Id, request.RemoteIpAddress);
                await _userRepository.Update(user);

                //generating access token
                AccessToken accessToken = await _jwtFactory.GenerateEncodedToken(user.Id.ToString(), user.UserName);

                //return tokens
                response = new UserLoginResponse(accessToken, refreshToken);

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
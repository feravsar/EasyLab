using System.Collections.Generic;
using EasyLab.Core.Dto.Auth;
using EasyLab.Core.Dto.User;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses
{

    public class UserLoginResponse : UseCaseResponseMessage
    {
        public AccessToken AccessToken { get; private set; }

        /// <summary>
        /// Token that is used in exchanging expired access token with the new one
        /// </summary>
        /// 
        public string RefreshToken { get; private set; }

        public UserInfo UserInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginResponse"/> class
        /// </summary>
        /// <param name="errors">Erros that occured during the process</param>
        public UserLoginResponse(IEnumerable<Error> errors) : base(errors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginResponse"/> class
        /// </summary>
        /// <param name="accessToken">Generated access token that is used to accessing protected API resources</param>
        /// <param name="refreshToken">Generated refresh tokenthat is used in exchanging expired access token with the new one </param>
        /// <param name="success">Specifies whether the operation is successful or not</param>
        /// <param name="message">Message that gives info about the operation</param>
        public UserLoginResponse(AccessToken accessToken, string refreshToken, string name, string surname, List<string> roles, bool success = true, string message = "User logged in successfully") : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            UserInfo = new UserInfo(name, surname, roles);
        }

    }
}
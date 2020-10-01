using EasyLab.Core.Dto.Auth;
using EasyLab.Core.Interfaces.UseCases;
using System.Collections.Generic;

namespace EasyLab.Core.Dto.UseCaseResponses.Auth
{
    /// <summary>
    /// Returns *new access token* and *new refresh token*
    ///</summary>
    public class ExchangeRefreshTokenResponse : UseCaseResponseMessage
    {
        /// <summary>
        /// Newly generated access token
        /// </summary>
        public AccessToken AccessToken { get; }
        
        /// <summary>
        /// Newly generated refresh token
        /// </summary>
        public string RefreshToken { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRefreshTokenResponse"/> class
        /// </summary>
        /// <param name="errors">Erros that occured during the process</param>
        public ExchangeRefreshTokenResponse(List<Error> errors) : base(errors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRefreshTokenResponse"/> class
        /// </summary>
        /// <param name="accessToken">Generated access token that is used to accessing protected API resources</param>
        /// <param name="refreshToken">Generated refresh tokenthat is used in exchanging expired access token with the new one </param>
        /// <param name="success">Specifies whether the operation is successful or not</param>
        /// <param name="message">Message that gives info about the operation</param>
        public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken, bool success = true, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
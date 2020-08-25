using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests
{
    public class ExchangeRefreshTokenRequest : IUseCaseRequest<ExchangeRefreshTokenResponse>
    {
        public string AccessToken { get; }

        public string RefreshToken { get; }

        public string SigningKey { get; }

        public ExchangeRefreshTokenRequest(string accessToken, string refreshToken, string signingKey)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            SigningKey = signingKey;
        }

    }

}
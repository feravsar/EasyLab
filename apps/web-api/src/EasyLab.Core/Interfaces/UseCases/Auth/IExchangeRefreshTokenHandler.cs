using EasyLab.Core.Dto.UseCaseRequests.Auth;
using EasyLab.Core.Dto.UseCaseResponses.Auth;

namespace EasyLab.Core.Interfaces.UseCases.Auth{

    public interface IExchangeRefreshTokenHandler : IUseCaseRequestHandler<ExchangeRefreshTokenRequest, ExchangeRefreshTokenResponse>
    {
        
    }
}
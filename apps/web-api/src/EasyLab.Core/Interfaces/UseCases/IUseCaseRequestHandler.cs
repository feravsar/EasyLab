using System.Threading.Tasks;

namespace EasyLab.Core.Interfaces.UseCases{
   public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task Handle(TUseCaseRequest request, IOutputPort<TUseCaseResponse> outputPort);
    }
}

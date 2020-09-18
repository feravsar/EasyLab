using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;

namespace EasyLab.Core.Interfaces.UseCases.Course{
    public interface IGetAssignmentsHandler : IUseCaseRequestHandler<GetAssignmentsRequest,GetAssignmentsResponse>{
    }
}
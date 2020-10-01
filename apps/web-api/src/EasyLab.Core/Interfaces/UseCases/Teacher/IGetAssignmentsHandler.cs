using EasyLab.Core.Dto.UseCaseRequests.Teacher;
using EasyLab.Core.Dto.UseCaseResponses.Teacher;

namespace EasyLab.Core.Interfaces.UseCases.Teacher{
    public interface IGetAssignmentsHandler : IUseCaseRequestHandler<GetAssignmentsRequest,GetAssignmentsResponse>{
    }
}
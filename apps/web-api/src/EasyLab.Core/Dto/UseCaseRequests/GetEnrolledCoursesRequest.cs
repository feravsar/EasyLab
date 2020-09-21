using System;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseRequests
{
    public class GetEnrolledCoursesRequest : IUseCaseRequest<GetEnrolledCoursesResponse>
    {
        public Guid UserId { get; }


        public GetEnrolledCoursesRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}

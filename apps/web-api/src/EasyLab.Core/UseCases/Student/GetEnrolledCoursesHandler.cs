using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Student;


namespace EasyLab.Core.UseCases.Student{
    public class GetEnrolledCoursesHandler : IGetEnrolledCoursesHandler
    {
        private readonly ICourseRepository _courseRepository;

        public GetEnrolledCoursesHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task Handle(GetEnrolledCoursesRequest request, IOutputPort<GetEnrolledCoursesResponse> outputPort)
        {
            var result = await _courseRepository.GetEnrolledCourses(request.UserId);
            outputPort.Handle(new GetEnrolledCoursesResponse(result));

        }
    }
}
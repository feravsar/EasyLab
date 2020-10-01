using System.Collections.Generic;
using System.Threading.Tasks;

using EasyLab.Core.Dto;
using EasyLab.Core.Dto.UseCaseRequests.Teacher;
using EasyLab.Core.Dto.UseCaseResponses.Teacher;
using EasyLab.Core.Helpers.Exceptions;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Teacher;

namespace EasyLab.Core.UseCases.Teacher
{
    public class GetAuthoredCoursesHandler : IGetAuthoredCoursesHandler
    {
        private readonly ICourseRepository _courseRespository;

        public GetAuthoredCoursesHandler(ICourseRepository courseRepository)
        {
            _courseRespository = courseRepository;
        }
        public async Task Handle(GetAuthoredCoursesRequest request, IOutputPort<GetAuthoredCoursesResponse> outputPort)
        {
            GetAuthoredCoursesResponse response = null;
            try
            {
                var result = await _courseRespository.GetAuthoredCourses(request.AuthorId);

                //return tokens
                response = new GetAuthoredCoursesResponse(result);

            }
         
            catch (System.Exception ex)
            {
                response = new GetAuthoredCoursesResponse(new List<Error>() { new Error(ex.GetType().Name, ex.Message) });
            }
            finally
            {
                outputPort.Handle(response);
            }
        }

     
    }
}
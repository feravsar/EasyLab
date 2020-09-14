using System.Collections.Generic;
using System.Threading.Tasks;
using EasyLab.Core.Dto;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Helpers.Exceptions;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Course;

namespace EasyLab.Core.UseCases.Course
{
    public class AddCourseHandler : IAddCourseHandler
    {
        private readonly ICourseRepository _courseRespository;

        public AddCourseHandler(ICourseRepository courseRepository)
        {
            _courseRespository = courseRepository;
        }
        public async Task Handle(AddCourseRequest request, IOutputPort<AddCourseResponse> outputPort)
        {
            AddCourseResponse response = null;
            try
            {
                var entity = await _courseRespository.Add(new Entities.Course
                {
                    Name = request.Name,
                    Description = request.Description,
                    DateCreated = request.DateCreated,
                    AuthorId = request.AuthorId,
                    IsActive = true
                });

                //return tokens
                response = new AddCourseResponse(entity.Id);

            }
            catch (EasyLabException ex)
            {
                response = new AddCourseResponse(new List<Error>() { new Error(ex.Code, ex.Message) });
            }
            catch (System.Exception ex)
            {
                response = new AddCourseResponse(new List<Error>() { new Error(ex.GetType().Name, ex.Message) });
            }
            finally
            {
                outputPort.Handle(response);
            }
        }
    }
}
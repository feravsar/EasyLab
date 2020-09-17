using System;
using System.Threading.Tasks;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Teacher;

namespace EasyLab.Core.UseCases.Teacher
{
    public sealed class GetMembersHandler : IGetMembersHandler
    {
        private readonly ICourseUsersRepository _courseUsersRepository;

        private readonly ICourseRepository _courseRepository;

        public GetMembersHandler(ICourseUsersRepository courseUsersRepository, ICourseRepository courseRepository)
        {
            _courseUsersRepository = courseUsersRepository;
            _courseRepository = courseRepository;
        }

        public async Task Handle(GetMembersRequest request, IOutputPort<GetMembersResponse> outputPort)
        {

            if (!(await _courseRepository.IsAuthoredAsTeacher(request.UserId, request.CourseId)))
                throw new Exception("You're not authorized for this action");


            var result = await _courseUsersRepository.GetMembers(request.CourseId);
            outputPort.Handle(new GetMembersResponse(result));
        }
    }
}
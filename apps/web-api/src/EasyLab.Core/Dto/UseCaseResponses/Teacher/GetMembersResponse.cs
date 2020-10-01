using System.Collections.Generic;
using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses.Teacher

{
    public class GetMembersResponse : UseCaseResponseMessage
    {
        public List<CourseUserDto> CourseUsers { get; private set; }
        public GetMembersResponse(IEnumerable<Error> errors, string message = "One or more errors occured during the process. See error messages for details") : base(errors, message)
        {
        }

        public GetMembersResponse(List<CourseUserDto> courseUsers) : base(true,"")
        {
            CourseUsers = courseUsers;
        }
    }
}
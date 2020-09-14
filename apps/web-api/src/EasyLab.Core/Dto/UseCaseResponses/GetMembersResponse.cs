using System.Collections.Generic;
using EasyLab.Core.Dto.Course;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses{
    public class GetMembersResponse : UseCaseResponseMessage
    {
        public List<CourseUserInfo> CourseUsers { get; private set; }
        public GetMembersResponse(IEnumerable<Error> errors, string message = "One or more errors occured during the process. See error messages for details") : base(errors, message)
        {
        }

        public GetMembersResponse(List<CourseUserInfo> courseUsers) : base(true,"")
        {
            CourseUsers = courseUsers;
        }
    }
}
using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses.Teacher
{
    public class SearchUserResponse : UseCaseResponseMessage
    {
        public SearchUserResponse(List<UserDto> users) : base(true, "")
        {
            Users = users;
        }

        public SearchUserResponse(IEnumerable<Error> errors, string message = "One or more errors occured during the process. See error messages for details") : base(errors, message)
        {
        }

        public List<UserDto> Users { get; }

    }
}

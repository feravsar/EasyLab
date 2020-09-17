using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.User;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses
{
    public class SearchUserResponse : UseCaseResponseMessage
    {
        public SearchUserResponse(List<UserInfo> users) : base(true, "")
        {
            Users = users;
        }

        public SearchUserResponse(IEnumerable<Error> errors, string message = "One or more errors occured during the process. See error messages for details") : base(errors, message)
        {
        }

        public List<UserInfo> Users { get; }

    }
}

using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.Auth;
using EasyLab.Core.Dto.Course;
using EasyLab.Core.Dto.User;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses
{
    public class GetAssignmentsResponse : UseCaseResponseMessage
    {   
        public GetAssignmentsResponse(IEnumerable<Error> errors) : base(errors)
        {
        }

        public GetAssignmentsResponse(List<AssignmentInfo> assignments, bool success = true, string message = "Course created successfully") : base(success, message)
        {
            Assignments = assignments;
        }
        public List<AssignmentInfo> Assignments { get; private set; }

    }
}
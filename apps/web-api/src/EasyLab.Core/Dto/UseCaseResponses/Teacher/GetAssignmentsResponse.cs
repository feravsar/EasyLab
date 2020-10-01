using System.Collections.Generic;

using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses.Teacher
{
    public class GetAssignmentsResponse : UseCaseResponseMessage
    {   
        public GetAssignmentsResponse(IEnumerable<Error> errors) : base(errors)
        {
        }

        public GetAssignmentsResponse(List<AssignmentDto> assignments, bool success = true, string message = "Course created successfully") : base(success, message)
        {
            Assignments = assignments;
        }
        public List<AssignmentDto> Assignments { get; private set; }

    }
}
using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses.Student
{
    public class GetProjectsResponse : UseCaseResponseMessage
    {
        public List<AssignmentDto> Assignments { get; private set; }


        
        public GetProjectsResponse(IEnumerable<Error> errors, string message = "One or more errors occured during the process. See error messages for details") : base(errors, message)
        {
        }

        public GetProjectsResponse(List<AssignmentDto> assignments,bool success=true, string message="") : base(success, message)
        {
            Assignments = assignments;
        }
    }
}

using System.Collections.Generic;
using EasyLab.Core.Dto;
using EasyLab.Core.Dto.GatewayResponses;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses.Student
{
    public class RunProjectResponse : UseCaseResponseMessage
    {
        public RunProjectResponse(IEnumerable<Error> errors, string message = "One or more errors occured during the process. See error messages for details") : base(errors, message)
        {
        }
        public RunProjectResponse(BashResponse bashResponse, bool success = true, string message = "") : base(success, message)
        {
            BashResponse = bashResponse;
        }
        public BashResponse BashResponse { get; private set; }
    }
}
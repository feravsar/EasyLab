using System;
using System.Collections.Generic;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses.Student
{
    public class GetFileContentResponse : UseCaseResponseMessage
    {


        public GetFileContentResponse(IEnumerable<Error> errors, string message = "One or more errors occured during the process. See error messages for details") : base(errors, message)
        {
        }
        public GetFileContentResponse(string fileContent, bool success = true, string message = "") : base(success, message)
        {
            FileContent = fileContent;
        }
        public string FileContent { get; private set; }
    }
}

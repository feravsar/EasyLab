using EasyLab.Core.Interfaces.UseCases;
using System.Collections.Generic;

namespace EasyLab.Core.Dto.UseCaseResponses
{
    /// <summary>
    /// Basic response for API calls. 
    /// It should be used in operations that return whether the operation was successful rather than return a specific object.
    /// </summary>
    public class BasicResponse : UseCaseResponseMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicResponse"/> class
        /// </summary>
        /// <param name="success">Specifies whether the operation is successful or not</param>
        /// <param name="message">Message that gives info about the operation</param>
        public BasicResponse(bool success = false, string message = "Operation failed") : base(success, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicResponse"/> class
        /// </summary>
        /// <param name="errors">Erros that occured during the process</param>
        public BasicResponse(IEnumerable<Error> errors) : base(errors)
        {
        }

    }
}

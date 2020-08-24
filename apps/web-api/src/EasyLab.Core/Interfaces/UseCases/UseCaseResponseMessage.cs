using EasyLab.Core.Dto;
using System.Collections.Generic;

namespace EasyLab.Core.Interfaces.UseCases
{

    /// <summary>
    ///Base response message class for use cases
    ///</summary>
    public abstract class UseCaseResponseMessage
    {

        /// <summary>
        /// Specifies whether the operation is successful or not
        /// </summary>
        public bool Success { get; private set; }

        ///<summary>
        ///Message that gives info about the operation
        ///</summary>
        public string Message { get; private set; }

        /// <summary>
        /// Errors that occured during the process
        /// </summary>
        public IEnumerable<Error> Errors { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UseCaseResponseMessage"/> class
        /// </summary>
        /// <param name="errors">Erros that occured during the process</param>
        /// <param name="message" default="One or more errors occured during the process. See error messages for details">Message to be shown to the user</param>
        public UseCaseResponseMessage(IEnumerable<Error> errors, string message = "One or more errors occured during the process. See error messages for details") 
        {
            Errors = errors;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UseCaseResponseMessage"/> class
        /// </summary>
        /// <param name="success">Specifies whether the operation is successful or not</param>
        /// <param name="message">Message to be shown to the user</param>
        protected UseCaseResponseMessage(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}

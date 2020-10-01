using System;
using System.Collections.Generic;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses.Account
{

    /// <summary>
    /// 
    /// It may contains following error codes: UserNotFound, VerificationCodeInvalid
    /// </summary>
    public class RegisterUserResponse : UseCaseResponseMessage
    {

        /// <summary>User Id</summary>
        public Guid Id { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserResponse"/> class
        /// </summary>
        /// <param name="errors">Erros that occured during the process</param>
        public RegisterUserResponse(IEnumerable<Error> errors) : base(errors)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserResponse"/> class
        /// </summary>
        /// <param name="id">Identifier of the user created.</param>
        /// <param name="success">Specifies whether the operation is successful or not</param>
        /// <param name="message">Message that gives info about the operation</param>
        public RegisterUserResponse(Guid id, bool success = true, string message = "User created successfully") : base(success, message)
        {
            Id = id;
        }
    }
}

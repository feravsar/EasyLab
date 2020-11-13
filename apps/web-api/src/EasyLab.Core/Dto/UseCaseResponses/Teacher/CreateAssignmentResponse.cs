using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.Auth;
using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses.Teacher
{
    public class CreateAssignmentResponse : UseCaseResponseMessage
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAssignmentResponse"/> class
        /// </summary>
        /// <param name="errors">Erros that occured during the process</param>
        public CreateAssignmentResponse(IEnumerable<Error> errors) : base(errors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAssignmentResponse"/> class
        /// </summary>
        public CreateAssignmentResponse(Guid id, bool success = true, string message = "Course created successfully") : base(success, message)
        {
            Id = id;
        }

    }
}
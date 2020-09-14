using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.Auth;
using EasyLab.Core.Dto.User;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses
{
    public class AddCourseResponse : UseCaseResponseMessage
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCourseResponse"/> class
        /// </summary>
        /// <param name="errors">Erros that occured during the process</param>
        public AddCourseResponse(IEnumerable<Error> errors) : base(errors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCourseResponse"/> class
        /// </summary>
        public AddCourseResponse(Guid id, bool success = true, string message = "Course created successfully") : base(success, message)
        {
            Id = id;
        }

    }
}
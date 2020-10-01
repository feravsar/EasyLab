using System.Collections.Generic;
using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses.Student
{
    public class GetEnrolledCoursesResponse : UseCaseResponseMessage
    {
        public List<CourseDto> Courses { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCourseResponse"/> class
        /// </summary>
        /// <param name="errors">Erros that occured during the process</param>
        public GetEnrolledCoursesResponse(IEnumerable<Error> errors) : base(errors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCourseResponse"/> class
        /// </summary>
        public GetEnrolledCoursesResponse(List<CourseDto> courses, bool success = true, string message = "Course created successfully") : base(success, message)
        {
            Courses = courses;
        }

    }
}
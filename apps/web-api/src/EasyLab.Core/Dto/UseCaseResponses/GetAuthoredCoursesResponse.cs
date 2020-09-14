using System.Collections.Generic;
using EasyLab.Core.Dto.Course;
using EasyLab.Core.Interfaces.UseCases;

namespace EasyLab.Core.Dto.UseCaseResponses
{
    public class GetAuthoredCoursesResponse : UseCaseResponseMessage
    {
        public List<CourseInfo> Courses { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCourseResponse"/> class
        /// </summary>
        /// <param name="errors">Erros that occured during the process</param>
        public GetAuthoredCoursesResponse(IEnumerable<Error> errors) : base(errors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCourseResponse"/> class
        /// </summary>
        public GetAuthoredCoursesResponse(List<CourseInfo> courses, bool success = true, string message = "Course created successfully") : base(success, message)
        {
            Courses = courses;
        }

    }
}
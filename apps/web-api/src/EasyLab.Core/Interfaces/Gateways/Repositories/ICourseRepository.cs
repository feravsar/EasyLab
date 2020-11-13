using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Entities;

namespace EasyLab.Core.Interfaces.Gateways.Repositories
{

    public interface ICourseRepository : IEfRepository<Course>
    {
        Task<List<CourseDto>> GetAuthoredCourses(Guid authorId);
        Task<bool> IsAuthoredAsTeacher(Guid userId, Guid courseId);
        Task<Course> GetCourseWithUsers(Guid courseId);
        Task<List<CourseDto>> GetEnrolledCourses(Guid userId);
    }

}

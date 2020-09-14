using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyLab.Core.Dto.Course;
using EasyLab.Core.Dto.GatewayResponses.Repositories;
using EasyLab.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace EasyLab.Core.Interfaces.Gateways.Repositories
{

    public interface ICourseRepository : IEfRepository<Course>
    {
        Task<List<CourseInfo>> GetAuthoredCourses(Guid authorId);
        Task<bool> IsAuthoredForMembersList(Guid userId, Guid courseId);
        Task<Course> GetCourseWithUsers(Guid courseId);
    }

}

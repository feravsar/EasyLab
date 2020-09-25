using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyLab.Core.Dto.Course;
using EasyLab.Core.Dto.GatewayResponses.Repositories;
using EasyLab.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace EasyLab.Core.Interfaces.Gateways.Repositories
{

    public interface ICourseUsersRepository : IEfRepository<CourseUsers>
    {
        Task<List<CourseUserInfo>> GetMembers(Guid courseId);
         Task<bool> IsUserEnrolledCourse(Guid courseId,Guid userId);
    }

}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EasyLab.Core.Dto.Entity;
using EasyLab.Core.Entities;

namespace EasyLab.Core.Interfaces.Gateways.Repositories
{

    public interface ICourseUserRepository : IEfRepository<CourseUser>
    {
        Task<List<CourseUserDto>> GetMembers(Guid courseId);
         Task<bool> IsUserEnrolledCourse(Guid courseId,Guid userId);
    }

}

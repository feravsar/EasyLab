using System.Linq;
using System.Threading.Tasks;
using EasyLab.Core.Dto;
using EasyLab.Core.Dto.GatewayResponses.Repositories;
using EasyLab.Core.Entities;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EasyLab.Core.Specifications;
using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.Course;

namespace EasyLab.Infrastructure.Data.Repositories
{
    public sealed class CourseUsersRepository : EfRepository<CourseUsers>, ICourseUsersRepository
    {
        public CourseUsersRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CourseUserInfo>> GetMembers(Guid courseId)
        {
            return await Queryable()
                .Where(t=>t.CourseId == courseId)
                .Select(t=>new CourseUserInfo(t.UserId,t.User.Name,t.User.Surname,t.User.Email,t.CourseId,t.IsInstructor,t.DateAdded))
                .ToListAsync();
        }

        public async Task<bool> IsUserEnrolledCourse(Guid courseId,Guid userId)
        {
            return await Queryable()
                .AnyAsync(t=>t.CourseId == courseId && t.UserId == userId && !t.IsInstructor);
        }
        
    }
}

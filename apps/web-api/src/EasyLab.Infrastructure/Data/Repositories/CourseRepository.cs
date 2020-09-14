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
    public sealed class CourseRepository : EfRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CourseInfo>> GetAuthoredCourses(Guid authorId)
        {
            return await Queryable()
              .Where(t => t.AuthorId == authorId)
              .Select(t => new CourseInfo(t.Id, t.Name, t.Description, t.DateCreated, t.Users.Count))
              .ToListAsync();
        }
        public async Task<bool> IsAuthoredForMembersList(Guid userId, Guid courseId)
        {
            return await Queryable()
                .AnyAsync(t => t.Id == courseId && (t.AuthorId == userId || t.Users.Any(u => u.UserId == userId && u.IsInstructor)));
        }

        public async Task<Course> GetCourseWithUsers(Guid courseId)
        {
            return await Queryable()
            .Include(t=>t.Users)
            .FirstOrDefaultAsync(t=>t.Id == courseId);
        }

    }
}
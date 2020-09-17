using AutoMapper;
using EasyLab.Core.Specifications;
using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.Course;
using EasyLab.Core.Entities;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyLab.Infrastructure.Data.Repositories
{
    public sealed class AssignmentRepository : EfRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<AssignmentInfo>> GetAssignments(Guid courseId)
        {
            return await Queryable()
                .Where(t=>t.CourseId == courseId)
                .Select(t=>new AssignmentInfo(t.Id,t.Author.Name + " " + t.Author.Surname, t.Due,t.DateCreated,t.Title,t.Description,t.Language.LanguageName))
                .ToListAsync();

        }
    }
}

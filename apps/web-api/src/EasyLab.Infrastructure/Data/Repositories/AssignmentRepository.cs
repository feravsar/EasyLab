using AutoMapper;
using EasyLab.Core.Specifications;
using System;
using System.Collections.Generic;
using EasyLab.Core.Dto.Entity;
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

        public async Task<List<AssignmentDto>> GetAssignments(Guid courseId)
        {
            return await Queryable()
                .Where(t => t.CourseId == courseId)
                .OrderBy(t => t.DateCreated)
                .Select(t => new AssignmentDto(t.Id, t.Author.Name + " " + t.Author.Surname, t.Due, t.DateCreated, t.Title, t.Description, t.Language.LanguageName))
                .ToListAsync();
        }


        public async Task<List<AssignmentDto>> GetProjects(Guid courseId, Guid userId)
        {
            return await Queryable()
                .Where(t => t.CourseId == courseId)
                .Select(t => new AssignmentDto(t.Id, t.Author.Name + " " + t.Author.Surname, t.Due, t.DateCreated, t.Title, t.Description, t.Language.LanguageName,
                    t.Projects.Where(a => a.UserId == userId).Select(p => new ProjectDto(p.ProjectId, p.DateStarted, p.DateFinished, p.Grade)).FirstOrDefault()))
                .ToListAsync();
        }

    }
}

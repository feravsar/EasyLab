using EasyLab.Core.Interfaces.Gateways.Repositories;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLab.Infrastructure.Data.Repositories
{

    public class EfRepository<T> : IEfRepository<T> where T : class
    {
        protected AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual async Task<T> GetById<S>(S id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }


        public async Task<T> GetSingleBySpec(ISpecification<T> spec)
        {
            var result = await List(spec);
            return result.FirstOrDefault();
        }

        public async Task<List<T>> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }


        public async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }


        public IQueryable<T> Queryable()
        {
            return _dbContext.Set<T>();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().AsNoTracking().Where(expression);
        }


        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

      
    }
}

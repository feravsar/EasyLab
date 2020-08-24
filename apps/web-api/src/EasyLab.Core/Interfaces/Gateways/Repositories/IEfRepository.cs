using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyLab.Core.Interfaces.Gateways.Repositories
{
    public interface IEfRepository<T>
    {
        Task<T> GetById<S>(S id);
        Task<T> GetSingleBySpec(ISpecification<T> spec);
        Task<List<T>> List(ISpecification<T> spec);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        IQueryable<T> Queryable();
        IEnumerable<T> Query(Expression<Func<T, bool>> expression);
        Task Save();
    }


}

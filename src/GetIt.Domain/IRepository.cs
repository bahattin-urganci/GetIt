using GetIt.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Domain
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Query { get; }
        T FindOne(Expression<Func<T, bool>> predicate);
        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(object source,T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}

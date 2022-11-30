using GetIt.Data;
using GetIt.Domain;
using GetIt.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly GetItDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(GetItDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public IQueryable<T> Query { get; private set; }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public Task AddAsync(T entity)
        {
            _ = _dbSet.AddAsync(entity);
            return Task.CompletedTask;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<T> entities) => _dbSet.AddRangeAsync(entities);

        public T FindOne(Expression<Func<T, bool>> predicate) => _dbSet.FirstOrDefault(predicate);

        public Task<T> FindOneAsync(Expression<Func<T, bool>> predicate) => _dbSet.FirstOrDefaultAsync(predicate);


        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(object source, T entity)
        {
            _db.Entry(entity).CurrentValues.SetValues(source);
            _dbSet.Update(entity);
        }
    }
}

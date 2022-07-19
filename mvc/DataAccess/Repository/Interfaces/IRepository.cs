using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace mvc.DataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IReadOnlyList<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);
        T Get(int id);
        T Get(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Modify(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
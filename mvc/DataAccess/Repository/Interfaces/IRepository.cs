using System.Linq.Expressions;

namespace mvc.DataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<(IReadOnlyList<T>, PaginationMetadata)> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null,
            int pageNumber = default, int pageSize = default);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Modify(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
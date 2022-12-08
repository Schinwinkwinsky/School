using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace School.Domain
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T? Get(int id);
        Task<T?> GetAsync(int id, CancellationToken cancellationToken);
        EntityEntry<T> Add(T entity);
        Task<EntityEntry<T>> AddAsync(T entity, CancellationToken cancellationToken);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        void AddRange(IEnumerable<T> entities);
        EntityEntry<T> Attach(T entity);
        EntityEntry<T> Update(T entity);
        EntityEntry<T> Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}

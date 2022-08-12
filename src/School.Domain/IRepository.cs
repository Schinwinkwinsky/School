using School.Domain.Entities;
using System.Linq.Expressions;

namespace School.Domain
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> GetAll(List<Expression<Func<TEntity, object>>>? includes = null, Expression<Func<TEntity, bool>>? predicate = null, bool tracking = true);
        Task<IQueryable<TEntity>> GetAllAsync(List<Expression<Func<TEntity, object>>>? includes = null, Expression<Func<TEntity, bool>>? predicate = null, bool tracking = true, CancellationToken cancellationToken = default);

        TEntity? GetById(int id, bool tracking = true);
        Task<TEntity?> GetByIdAsync(int id, bool tracking = true, CancellationToken cancellationToken = default);

        void Add(TEntity entity);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}

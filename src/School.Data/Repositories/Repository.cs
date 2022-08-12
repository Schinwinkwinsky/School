using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain;
using System.Linq.Expressions;

namespace School.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
            => _context = context;

        public void Add(TEntity entity)
            => _context.Set<TEntity>().Add(entity);

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
            => await _context.Set<TEntity>().AddAsync(entity, cancellationToken);

        public void AddRange(IEnumerable<TEntity> entities)
            => _context.Set<TEntity>().AddRange(entities);

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            => _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

        public IQueryable<TEntity> GetAll(List<Expression<Func<TEntity, object>>>? includes = null, Expression<Func<TEntity, bool>>? predicate = null, bool tracking = true)
        {
            var query = tracking ? _context.Set<TEntity>() : _context.Set<TEntity>().AsNoTracking();

            if (includes is not null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate is not null)
                query = query.Where(predicate);

            return query;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(List<Expression<Func<TEntity, object>>>? includes = null, Expression<Func<TEntity, bool>>? predicate = null, bool tracking = true, CancellationToken cancellationToken = default)
        {
            var query = tracking ? _context.Set<TEntity>() : _context.Set<TEntity>().AsNoTracking();

            if (includes is not null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate is not null)
                query = query.Where(predicate);

            return await Task.FromResult(query);
        }

        public TEntity? GetById(int id, bool tracking = true)
            => tracking
                ? _context.Set<TEntity>().FirstOrDefault(e => e.Id == id)
                : _context.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id == id);

        public async Task<TEntity?> GetByIdAsync(int id, bool tracking = true, CancellationToken cancellationToken = default)
            => tracking
                ? await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken)
                : await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        public void Remove(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
            => await Task.Run(() => _context.Set<TEntity>().Remove(entity), cancellationToken);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => _context.Set<TEntity>().RemoveRange(entities);

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            => await Task.Run(() => _context.Set<TEntity>().RemoveRange(), cancellationToken);

        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
            => await Task.Run(() => _context.Set<TEntity>().Update(entity), cancellationToken);
    }
}

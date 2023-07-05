using Microsoft.EntityFrameworkCore;
using School.Domain;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace School.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public Repository(DataContext context) => _context = context;

        public IQueryable<T> GetAll() => _context.Set<T>();

        public T? Get(Guid id) => _context.Set<T>().Find(id);

        public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken) 
            => await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken:cancellationToken);

        public EntityEntry<T> Add(T entity) => _context.Set<T>().Add(entity);

        public async Task<EntityEntry<T>> AddAsync(T entity, CancellationToken cancellationToken)
            => await _context.Set<T>().AddAsync(entity, cancellationToken);

        public bool Any(Expression<Func<T, bool>> predicate) => _context.Set<T>().Any(predicate);

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) 
            => await _context.Set<T>().AnyAsync(predicate);

        public void AddRange(IEnumerable<T> entities) => _context.Set<T>().AddRange(entities);

        public EntityEntry<T> Attach(T entity) => _context.Set<T>().Attach(entity);

        public EntityEntry<T> Update(T entity) => _context.Set<T>().Update(entity);

        public EntityEntry<T> Remove(T entity) => _context.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);        
    }
}

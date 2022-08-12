using School.Domain.Entities;
using School.Domain;
using System.Collections;
using School.Data.Repositories;

namespace School.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private Hashtable _repositories = new();

        public UnitOfWork(DataContext context)
            => _context = context;

        public IRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase
        {
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type]!;
        }

        public void SaveChanges()
            => _context.SaveChanges();

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
            => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

using School.Domain.Entities;

namespace School.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;

        void SaveChanges();

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

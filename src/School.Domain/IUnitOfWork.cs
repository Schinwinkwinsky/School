using School.Domain.Entities;

namespace School.Domain;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;

    void SaveChanges();

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

using School.Domain.Entities;

namespace School.Application.DTO;

public interface IDto<T> where T : EntityBase
{
    public Guid Id { get; set; }

    void CopyToEntity(T item);
}

using School.Domain.Entities;

namespace School.Application.Models
{
    public interface IModel<T> where T : EntityBase
    {
         T ToEntity();
    }
}

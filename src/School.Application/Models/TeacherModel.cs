using School.Domain.Entities;

namespace School.Application.Models;

public class TeacherModel : IModel<Teacher>
{
    public Guid PersonId { get; set; }

    public Teacher ToEntity()
    {
        return new Teacher() 
        { 
            PersonId = PersonId 
        };
    }
}

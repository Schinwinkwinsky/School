using School.Domain.Entities;

namespace School.Application.Models;

public class StudentModel : IModel<Student>
{
    public Guid PersonId { get; set; }

    public Student ToEntity()
    {
        return new Student
        {
            PersonId = PersonId
        };
    }
}

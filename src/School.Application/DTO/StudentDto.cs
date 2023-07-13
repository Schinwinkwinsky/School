using School.Domain.Entities;

namespace School.Application.DTO;

public class StudentDto : IDto<Student>
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }
    public PersonDto? Person { get; set; }

    public ICollection<SchoolClassDto>? SchoolClasses { get; set; }

    public void CopyToEntity(Student student)
    {
        student.Id = Id;
        student.PersonId = PersonId;
    }
}

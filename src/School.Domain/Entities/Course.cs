namespace School.Domain.Entities;

public class Course : EntityBase
{
    public string Name { get; set; } = default!;

    public virtual ICollection<Subject> Subjects { get; set; } = default!;
}

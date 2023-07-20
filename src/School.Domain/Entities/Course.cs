namespace School.Domain.Entities;

public class Course : EntityBase
{
    public string Name { get; set; } = default!;

    // Navigation properties.
    public virtual ICollection<Period> Periods{ get; set; } = default!;
    public virtual ICollection<Subject> Subjects { get; set; } = default!;
}

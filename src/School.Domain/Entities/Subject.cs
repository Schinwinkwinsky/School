namespace School.Domain.Entities;

public class Subject : EntityBase
{
    public string Name { get; set; } = default!;

    // Navigation properties.
    public virtual ICollection<Course> Courses { get; set; } = default!;
    public virtual ICollection<KnowledgeArea> KnowledgeAreas { get; set; } = default!;
    public virtual ICollection<Period> Periods { get; set; } = default!;
}

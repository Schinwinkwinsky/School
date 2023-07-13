namespace School.Domain.Entities;

public class KnowledgeArea : EntityBase
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    // Navigation properties.
    public virtual ICollection<Subject> Subjects { get; set; } = default!;
    public virtual ICollection<Teacher> Teachers { get; set; } = default!;
}

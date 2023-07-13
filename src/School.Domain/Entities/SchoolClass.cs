namespace School.Domain.Entities;

public class SchoolClass : EntityBase
{
    public string Code { get; set; } = string.Empty;

    // Navigation properties.
    public Guid PeriodId { get; set; }
    public virtual Period Period { get; set; } = new();

    public Guid SubjectId { get; set; }
    public virtual Subject Subject { get; set; } = new();

    public Guid TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; } = new();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

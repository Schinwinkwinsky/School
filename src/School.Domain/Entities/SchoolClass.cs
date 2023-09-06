using School.Domain.Relations;

namespace School.Domain.Entities;

public class SchoolClass : EntityBase
{
    public string Code { get; set; } = default!;

    // Navigation properties.
    public Guid PeriodId { get; set; }
    public virtual Period Period { get; set; } = default!;

    public Guid SubjectId { get; set; }
    public virtual Subject Subject { get; set; } = default!;

    public Guid TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; } = default!;

    public virtual ICollection<Student> Students { get; set; } = default!;

    public virtual ICollection<SchoolClassStudent> SchoolClassStudent { get; set; } = default!;
}

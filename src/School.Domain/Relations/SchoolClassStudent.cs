using School.Domain.Entities;

namespace School.Domain.Relations;

public class SchoolClassStudent : RelationBase
{
    public Guid SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; } = default!;

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = default!;
}

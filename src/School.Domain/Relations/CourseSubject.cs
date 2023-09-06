using School.Domain.Entities;

namespace School.Domain.Relations;

public class CourseSubject : RelationBase
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; } = default!;

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = default!;
}

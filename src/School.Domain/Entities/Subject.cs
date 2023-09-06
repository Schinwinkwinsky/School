using School.Domain.Relations;

namespace School.Domain.Entities;

public class Subject : EntityBase
{
    public string Name { get; set; } = default!;

    // Navigation properties.
    public virtual ICollection<Course> Courses { get; set; } = default!;
    public virtual ICollection<KnowledgeArea> KnowledgeAreas { get; set; } = default!;
    public virtual ICollection<SchoolClass> SchoolClasses { get; set; } = default!;

    public virtual ICollection<CourseSubject> CourseSubject { get; set; } = default!;
    public virtual ICollection<KnowledgeAreaSubject> KnowledgeAreaSubject { get; set; } = default!;
}

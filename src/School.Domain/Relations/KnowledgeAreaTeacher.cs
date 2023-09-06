using School.Domain.Entities;

namespace School.Domain.Relations;

public class KnowledgeAreaTeacher : RelationBase
{
    public Guid KnowledgeAreaId { get; set; }
    public KnowledgeArea KnowledgeArea { get; set; } = default!;

    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = default!;
}

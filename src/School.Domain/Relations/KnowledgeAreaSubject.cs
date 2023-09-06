using School.Domain.Entities;

namespace School.Domain.Relations;

public class KnowledgeAreaSubject : RelationBase
{
    public Guid KnowledgeAreaId { get; set; }
    public KnowledgeArea KnowledgeArea { get; set; } = default!;

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = default!;
}

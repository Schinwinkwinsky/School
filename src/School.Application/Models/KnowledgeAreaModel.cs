using School.Domain.Entities;

namespace School.Application.Models;

public class KnowledgeAreaModel : IModel<KnowledgeArea>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public KnowledgeArea ToEntity()
    {
        return new KnowledgeArea
        {
            Name = Name,
            Description = Description
        };
    }
}

namespace School.Domain.Entities
{
    public class Subject : EntityBase
    {
        public string Name { get; set; } = default!;

        // Navigation properties.
        public virtual ICollection<KnowledgeArea> KnowledgeAreas { get; set; } = default!;
    }
}

namespace School.Domain.Entities
{
    public class Subject : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        // Navigation properties.
        public int KnowledgeAreaId { get; set; }
        public KnowledgeArea? KnowledgeArea { get; set; }
    }
}

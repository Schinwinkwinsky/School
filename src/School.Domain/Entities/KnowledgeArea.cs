namespace School.Domain.Entities
{
    public class KnowledgeArea : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation properties.
        public IEnumerable<Subject>? Subjects { get; set; }
    }
}

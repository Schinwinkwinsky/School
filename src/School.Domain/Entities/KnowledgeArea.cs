namespace School.Domain.Entities
{
    public class KnowledgeArea : EntityBase
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        // Navigation properties.
        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
    }
}

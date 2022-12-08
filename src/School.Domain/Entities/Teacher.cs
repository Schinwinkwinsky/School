namespace School.Domain.Entities
{
    public class Teacher : Person
    {
        // Navigation properties.
        public IEnumerable<KnowledgeArea> KnowledgeAreas { get; set; } = null!;
    }
}

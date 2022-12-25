namespace School.Domain.Entities
{
    public class Teacher : Person
    {
        // Navigation properties.
        public ICollection<KnowledgeArea>? KnowledgeAreas { get; set; }
        public ICollection<SchoolClass>? SchoolClasses { get; set; }
    }
}

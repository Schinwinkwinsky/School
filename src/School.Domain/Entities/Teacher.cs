namespace School.Domain.Entities
{
    public class Teacher : EntityBase
    {
        public bool IsActive { get; set; }

        // Navigation properties.
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public ICollection<KnowledgeArea>? KnowledgeAreas { get; set; }
        public ICollection<SchoolClass>? SchoolClasses { get; set; }
    }
}

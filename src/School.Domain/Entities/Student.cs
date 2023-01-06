namespace School.Domain.Entities
{
    public class Student : EntityBase
    {
        public bool IsActive { get; set; }

        // Navigation properties.
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public ICollection<SchoolClass>? SchoolClasses { get; set; }
    }
}

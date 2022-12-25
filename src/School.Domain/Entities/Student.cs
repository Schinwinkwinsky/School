namespace School.Domain.Entities
{
    public class Student : Person
    {
        // Navigation properties.
        public ICollection<SchoolClass>? SchoolClasses { get; set; }
    }
}

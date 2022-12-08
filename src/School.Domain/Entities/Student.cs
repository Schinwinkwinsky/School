namespace School.Domain.Entities
{
    public class Student : Person
    {
        // Navigation properties.
        public IEnumerable<SchoolClass>? SchoolClasses { get; set; }
    }
}

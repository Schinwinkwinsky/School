namespace School.Domain.Entities
{
    public class Student : EntityBase
    {
        // Navigation properties.
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; } = default!;

        public virtual ICollection<SchoolClass> SchoolClasses { get; set; } = default!;
    }
}

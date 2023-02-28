namespace School.Domain.Entities
{
    public class Period : EntityBase
    {
        public string Code { get; set; } = default!;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        // Navigation properties.
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = default!;

        public virtual ICollection<SchoolClass> SchoolClasses { get; set; } = default!;
    }
}

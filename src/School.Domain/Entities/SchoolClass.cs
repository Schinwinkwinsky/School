namespace School.Domain.Entities
{
    public class SchoolClass : EntityBase
    {
        public string Code { get; set; } = default!;

        // Navigation properties.
        public int PeriodId { get; set; }
        public virtual Period Period { get; set; } = default!;

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; } = default!;

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; } = default!;

        public virtual ICollection<Student> Students { get; set; } = default!;
    }
}

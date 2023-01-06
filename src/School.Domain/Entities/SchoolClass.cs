namespace School.Domain.Entities
{
    public class SchoolClass : EntityBase
    {
        public string Code { get; set; } = null!;
        public bool IsActive { get; set; }

        // Navigation properties.
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        public ICollection<Student>? Students { get; set; }
    }
}

namespace School.Domain.Entities
{
    public class SchoolClass : EntityBase
    {
        public string Code { get; set; } = string.Empty;
        public bool IsClosed { get; set; } = false;


        // Navigation properties.
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = new();

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = new();

        public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>();
    }
}

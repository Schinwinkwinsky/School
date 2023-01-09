namespace School.Domain.Entities
{
    public class SchoolClassStudent
    {
        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; } = default!;

        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;
    }
}

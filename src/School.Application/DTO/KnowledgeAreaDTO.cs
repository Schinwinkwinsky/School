namespace School.Application.DTO
{
    public class KnowledgeAreaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation properties.
        public IEnumerable<SubjectDTO>? Subjects { get; set; }
    }
}

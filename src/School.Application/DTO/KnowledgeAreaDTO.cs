namespace School.Application.DTO
{
    public class KnowledgeAreaDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation properties.
        public IEnumerable<SubjectDto>? Subjects { get; set; }
    }
}

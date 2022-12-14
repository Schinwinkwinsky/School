namespace School.Application.DTO
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties.
        public int KnowledgeAreaId { get; set; }
        public KnowledgeAreaDto? KnowledgeArea { get; set; }
    }
}

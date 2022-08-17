namespace School.Application.DTO
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties.
        public int KnowledgeAreaId { get; set; }
        public KnowledgeAreaDTO? KnowledgeArea { get; set; }
    }
}

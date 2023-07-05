using School.Domain.Entities;

namespace School.Application.DTO
{
    public class KnowledgeAreaDto : IDto<KnowledgeArea>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation properties.
        public ICollection<SubjectDto>? Subjects { get; set; }
        public ICollection<TeacherDto>? Teachers { get; set; }

        public void CopyToEntity(KnowledgeArea area)
        {
            area.Name = Name;
            area.Description = Description;
        }
    }
}

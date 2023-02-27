using School.Domain.Entities;

namespace School.Application.DTO
{
    public class TeacherDto
    {
        // Navigation properties.
        public int PersonId { get; set; }
        public PersonDto? Person { get; set; }

        public ICollection<KnowledgeAreaDto>? KnowledgeAreas { get; set; }
        public ICollection<SchoolClassDto>? SchoolClasses { get; set; }
    }
}

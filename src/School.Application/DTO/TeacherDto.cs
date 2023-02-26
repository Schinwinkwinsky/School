using School.Domain.Entities;

namespace School.Application.DTO
{
    public class TeacherDto
    {
        // Navigation properties.
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        public ICollection<KnowledgeArea>? KnowledgeAreas { get; set; }
        public ICollection<SchoolClass>? SchoolClasses { get; set; }
    }
}

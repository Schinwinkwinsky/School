using School.Domain.Entities;

namespace School.Application.DTO
{
    public class TeacherDto : IDto<Teacher>
    {
        public Guid Id { get; set; }

        // Navigation properties.
        public Guid PersonId { get; set; }
        public PersonDto? Person { get; set; }

        public ICollection<KnowledgeAreaDto>? KnowledgeAreas { get; set; }
        public ICollection<SchoolClassDto>? SchoolClasses { get; set; }

        public void CopyToEntity(Teacher item)
        {
            item.Id = Id;
            item.PersonId = PersonId;
        }
    }
}

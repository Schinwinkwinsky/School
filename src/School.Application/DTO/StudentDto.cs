using School.Domain.Entities;

namespace School.Application.DTO
{
    public class StudentDto
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; } = default!;

        public virtual ICollection<SchoolClass> SchoolClasses { get; set; } = default!;
    }
}

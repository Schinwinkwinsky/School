using School.Domain.Entities;

namespace School.Application.DTO
{
    public class CourseDto : IDto<Course>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Subject> Subjects { get; set; } = default!;

        public void CopyToEntity(Course item)
        {
            item.Id = Id;
            item.Name = Name;
        }
    }
}

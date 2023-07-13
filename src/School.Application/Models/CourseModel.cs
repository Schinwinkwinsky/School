using School.Domain.Entities;

namespace School.Application.Models;

public class CourseModel : IModel<Course>
{
    public string Name { get; set; } = string.Empty;

    public Course ToEntity()
    {
        return new Course { Name = Name };
    }
}

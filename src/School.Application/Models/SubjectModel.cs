using School.Domain.Entities;

namespace School.Application.Models;

public class SubjectModel : IModel<Subject>
{
    public string Name { get; set; } = string.Empty;

    public Subject ToEntity()
    {
        return new Subject
        {
            Name = Name
        };
    }
}

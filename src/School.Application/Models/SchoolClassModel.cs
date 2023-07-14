using School.Domain.Entities;

namespace School.Application.Models;

public class SchoolClassModel : IModel<SchoolClass>
{
    public string Code { get; set; } = default!;

    // Navigation properties.
    public Guid PeriodId { get; set; }

    public Guid SubjectId { get; set; }

    public Guid TeacherId { get; set; }

    public SchoolClass ToEntity()
    {
        return new SchoolClass
        {
            Code = Code,
            PeriodId = PeriodId,
            SubjectId = SubjectId,
            TeacherId = TeacherId
        };
    }
}

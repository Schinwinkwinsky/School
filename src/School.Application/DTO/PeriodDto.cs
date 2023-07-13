using School.Domain.Entities;

namespace School.Application.DTO;

public class PeriodDto : IDto<Period>
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    // Navigation properties.
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }

    public ICollection<SchoolClassDto>? SchoolClasses { get; set; }

    public void CopyToEntity(Period period)
    {
        period.Id = Id;
        period.Code = Code;
        period.Start = Start;
        period.End = End;
        period.CourseId = CourseId;
    }
}

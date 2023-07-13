using School.Domain.Entities;

namespace School.Application.Models;

public class PeriodModel : IModel<Period>
{
    public string Code { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Navigation properties.
    public Guid CourseId { get; set; }

    public Period ToEntity()
    {
        return new Period 
        { 
            Code = Code, 
            StartDate = StartDate, 
            EndDate = EndDate,
            CourseId = CourseId
        };
    }
}

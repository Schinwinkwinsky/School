using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(c => c.Periods, opt => 
            {
                opt.ExplicitExpansion();
                opt.MapFrom(c => c.Periods.Where(p => p.DeletedAt == default));
            })
            .ForMember(c => c.Subjects, opt =>
            {
                opt.ExplicitExpansion();
                opt.MapFrom(c => c.Subjects.Where(s => s.DeletedAt == default));
            });
    }
}

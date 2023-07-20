using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(c => c.Periods, opt => opt.ExplicitExpansion())
            .ForMember(c => c.Subjects, opt => opt.ExplicitExpansion());
    }
}

using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class PeriodProfile : Profile
{
    public PeriodProfile()
    {
        CreateMap<Period, PeriodDto>()
            .ForMember(p => p.Course, opt => opt.ExplicitExpansion())
            .ForMember(p => p.SchoolClasses, opt =>
            {
                opt.ExplicitExpansion();
                opt.MapFrom(p => p.SchoolClasses.Where(sc => sc.DeletedAt == default));
            });
    }
}

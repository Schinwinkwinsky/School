using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class SchoolClassProfile : Profile
{
    public SchoolClassProfile() 
    {
        CreateMap<SchoolClass, SchoolClassDto>()
            .ForMember(sc => sc.Period, opt => opt.ExplicitExpansion())
            .ForMember(sc => sc.Subject, opt => opt.ExplicitExpansion())
            .ForMember(sc => sc.Teacher, opt => opt.ExplicitExpansion())
            .ForMember(sc => sc.Students, opt => opt.ExplicitExpansion());
    }
}

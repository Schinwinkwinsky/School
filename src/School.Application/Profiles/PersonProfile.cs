using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonDto>()
            .ForMember(p => p.Students, opt => opt.ExplicitExpansion())
            .ForMember(p => p.Teachers, opt => opt.ExplicitExpansion());
    }            
}

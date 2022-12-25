using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Addresses, opt => opt.ExplicitExpansion())
                .ForMember(dest => dest.Emails, opt => opt.ExplicitExpansion())
                .ForMember(dest => dest.Phones, opt => opt.ExplicitExpansion());
        }            
    }
}

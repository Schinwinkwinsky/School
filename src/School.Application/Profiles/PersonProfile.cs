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
                .ForMember(p => p.Addresses, opt => opt.ExplicitExpansion())
                .ForMember(p => p.Emails, opt => opt.ExplicitExpansion())
                .ForMember(p => p.Phones, opt => opt.ExplicitExpansion());
        }            
    }
}

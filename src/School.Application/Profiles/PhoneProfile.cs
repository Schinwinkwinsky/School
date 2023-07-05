using AutoMapper;
using School.Application.DTO;
using School.Domain.ValueObjects;

namespace School.Application.Profiles
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<Phone, PhoneDto>();
        }
    }
}

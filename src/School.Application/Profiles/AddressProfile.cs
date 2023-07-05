using AutoMapper;
using School.Application.DTO;
using School.Domain.ValueObjects;

namespace School.Application.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>();
        }
    }
}

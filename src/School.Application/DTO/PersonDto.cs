using School.Domain.Entities;
using School.Domain.ValueObjects;

namespace School.Application.DTO
{
    public class PersonDto : IDto<Person>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Birth { get; set; }

        public ICollection<AddressDto>? Addresses { get; set; }
        public ICollection<EmailDto>? Emails { get; set; }
        public ICollection<PhoneDto>? Phones { get; set; }

        public void CopyToEntity(Person person)
        {
            person.Id = Id;
            person.Name = Name;
            person.Birth = Birth;
            person.Addresses = Addresses?.Select<AddressDto, Address>(a => a).ToList() ?? new List<Address>();
            person.Emails = Emails?.Select<EmailDto, Email>(e => e).ToList() ?? new List<Email>();
            person.Phones = Phones?.Select<PhoneDto, Phone>(p => p).ToList() ?? new List<Phone>();
        }
    }
}

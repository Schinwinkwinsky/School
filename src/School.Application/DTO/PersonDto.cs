using School.Domain.Entities;
using School.Domain.ValueObjects;

namespace School.Application.DTO;

public class PersonDto : IDto<Person>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Birth { get; set; }

    public ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    public ICollection<EmailDto> Emails { get; set; } = new List<EmailDto>();
    public ICollection<PhoneDto> Phones { get; set; } = new List<PhoneDto>();

    public void CopyToEntity(Person person)
    {
        person.Id = Id;
        person.Name = Name;
        person.Birth = Birth;
        person.Addresses = Addresses.Select<AddressDto, Address>(a => a).ToList();
        person.Emails = Emails.Select<EmailDto, Email>(e => e).ToList();
        person.Phones = Phones.Select<PhoneDto, Phone>(p => p).ToList();
    }
}

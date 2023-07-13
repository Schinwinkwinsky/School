using School.Domain.Entities;
using School.Domain.ValueObjects;

namespace School.Application.DTO;

public class PersonDto : IDto<Person>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime Birth { get; set; }

    public ICollection<AddressDto> Addresses { get; set; } = default!;
    public ICollection<EmailDto> Emails { get; set; } = default!;
    public ICollection<PhoneDto> Phones { get; set; } = default!;

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

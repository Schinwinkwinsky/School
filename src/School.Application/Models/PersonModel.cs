using School.Domain.Entities;
using School.Domain.ValueObjects;

namespace School.Application.Models;

public class PersonModel : IModel<Person>
{
    public string Name { get; set; } = default!;
    public DateTime Birth { get; set; }

    public ICollection<AddressModel>? Addresses { get; set; }
    public ICollection<EmailModel>? Emails { get; set; }
    public ICollection<PhoneModel>? Phones { get; set; }


    public Person ToEntity()
    {
        return new Person 
        { 
            Name = Name, 
            Birth = Birth,
            Addresses = Addresses?.Select<AddressModel, Address>(a => a).ToList() ?? new(),
            Emails = Emails?.Select<EmailModel, Email>(e => e).ToList() ?? new(),
            Phones = Phones?.Select<PhoneModel, Phone>(p => p).ToList() ?? new()
        };
    }
}

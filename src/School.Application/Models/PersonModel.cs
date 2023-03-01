using School.Domain.Entities;

namespace School.Application.Models
{
    public class PersonModel : IModel<Person>
    {
        public string Name { get; set; } = default!;
        public DateTime Birth { get; set; }

        public ICollection<AddressModel>? Addresses { get; set; }
        public ICollection<EmailModel>? Emails { get; set; }
        public ICollection<PhoneModel>? Phones { get; set; }


        public Person ToEntity()
        {
            var person = new Person 
            { 
                Name = Name, 
                Birth = Birth
            };

            if (Addresses is not null)
                foreach (var model in Addresses)
                    person.Addresses.Add(model);

            if (Emails is not null)
                foreach (var model in Emails)
                    person.Emails.Add(model);

            if (Phones is not null)
                foreach (var model in Phones)
                    person.Phones.Add(model);

            return person;
        }
    }
}

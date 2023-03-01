using School.Domain.Entities;

namespace School.Application.DTO
{
    public class PersonDto : IDto<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Birth { get; set; }

        public ICollection<AddressDto>? Addresses { get; set; }
        public ICollection<EmailDto>? Emails { get; set; }
        public ICollection<PhoneDto>? Phones { get; set; }

        public void CopyToEntity(Person item)
        {
            item.Id = Id;
            item.Name = Name;
            item.Birth = Birth;

            if (Addresses is not  null)
                foreach (var dto in Addresses)            
                    item.Addresses.Add(dto);

            if (Emails is not null)
                foreach (var dto in Emails)
                    item.Emails.Add(dto);

            if (Phones is not null)
                foreach (var dto in Phones)
                    item.Phones.Add(dto);
        }
    }
}

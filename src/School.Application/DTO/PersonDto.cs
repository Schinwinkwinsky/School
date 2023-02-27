using School.Domain.Entities;

namespace School.Application.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Birth { get; set; }

        public ICollection<AddressDto>? Addresses { get; set; }
        public ICollection<EmailDto>? Emails { get; set; }
        public ICollection<PhoneDto>? Phones { get; set; }
    }
}

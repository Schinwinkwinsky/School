using School.Domain.Entities;

namespace School.Application.DTO
{
    public class PersonDto
    {
        public string Name { get; set; } = null!;
        public DateTime Birth { get; set; }

        public ICollection<Address>? Addresses { get; set; }
        public ICollection<Email>? Emails { get; set; }
        public ICollection<Phone>? Phones { get; set; }
    }
}

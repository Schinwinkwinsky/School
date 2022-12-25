namespace School.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; } = null!;
        public DateTime Birth { get; set; }

        public ICollection<Address>? Addresses { get; set; }
        public ICollection<Email>? Emails { get; set; }
        public ICollection<Phone>? Phones { get; set; }
    }
}

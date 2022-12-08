namespace School.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; } = null!;
        public DateTime Birth { get; set; }

        public IEnumerable<Address> Addresses { get; set; } = null!;
        public IEnumerable<Email> Emails { get; set; } = null!;
        public IEnumerable<Phone> Phones { get; set; } = null!;
    }
}

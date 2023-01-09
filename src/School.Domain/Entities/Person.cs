namespace School.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; } = default!;
        public DateTime Birth { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = default!;
        public virtual ICollection<Email> Emails { get; set; } = default!;
        public virtual ICollection<Phone> Phones { get; set; } = default!;
    }
}

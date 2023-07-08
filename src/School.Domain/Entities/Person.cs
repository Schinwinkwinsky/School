using School.Domain.ValueObjects;
using System.Collections.ObjectModel;

namespace School.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; } = default!;
        public DateTime Birth { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new Collection<Address>();
        public virtual ICollection<Email> Emails { get; set; } = new Collection<Email>();
        public virtual ICollection<Phone> Phones { get; set; } = new Collection<Phone>();
    }
}

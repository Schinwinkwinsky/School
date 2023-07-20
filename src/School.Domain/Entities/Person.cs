using School.Domain.ValueObjects;

namespace School.Domain.Entities;

public class Person : EntityBase
{
    public string Name { get; set; } = default!;
    public DateTime Birth { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = default!;
    public virtual ICollection<Email> Emails { get; set; } = default!;
    public virtual ICollection<Phone> Phones { get; set; } = default!;

    // Navigation properties.
    public virtual ICollection<Student> Students { get; set; } = default!;
    public virtual ICollection<Teacher> Teachers { get; set; } = default!;
}

namespace School.Domain.Entities
{
    public class Student : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Birth { get; set; }

        public IEnumerable<Address> Addresses { get; set; } = Enumerable.Empty<Address>();
        public IEnumerable<Phone> Phones { get; set; } = Enumerable.Empty<Phone>();

        // Navigation properties.
        public IEnumerable<SchoolClass> SchoolClasses { get; set; } = Enumerable.Empty<SchoolClass>();
    }
}

namespace School.Domain.Entities
{
    public class Teacher : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Birth { get; set; }

        public IEnumerable<Address> Addresses { get; set; } = Enumerable.Empty<Address>();
        public IEnumerable<Phone> Phones { get; set; } = Enumerable.Empty<Phone>();

        // Navigation properties.
        public IEnumerable<KnowledgeArea> KnowledgeAreas { get; set; } = Enumerable.Empty<KnowledgeArea>();
        public IEnumerable<SchoolClass> SchoolClasses { get; set; } = Enumerable.Empty<SchoolClass>();
    }
}

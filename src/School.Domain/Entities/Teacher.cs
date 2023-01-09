﻿namespace School.Domain.Entities
{
    public class Teacher : EntityBase
    {
        public bool IsActive { get; set; }

        // Navigation properties.
        public int PersonId { get; set; }
        public virtual Person Person { get; set; } = default!;

        public virtual ICollection<KnowledgeArea> KnowledgeAreas { get; set; } = default!;
        public virtual ICollection<SchoolClass> SchoolClasses { get; set; } = default!;
    }
}

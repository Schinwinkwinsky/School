﻿namespace School.Domain.Entities
{
    public class SchoolClass : EntityBase
    {
        public string Code { get; set; } = null!;
        public bool IsClosed { get; set; }


        // Navigation properties.
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        public IEnumerable<Student>? Students { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;
using School.Domain.Relations;

namespace School.Data.EntityTypeConfigurations;

public class StudentEntityTypeConfigurations : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasOne<Person>(s => s.Person)
            .WithMany(p => p.Students)
            .HasForeignKey(s => s.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany<SchoolClass>(s => s.SchoolClasses)
            .WithMany(sc => sc.Students)
            .UsingEntity<SchoolClassStudent>(
                l => l.HasOne<SchoolClass>(scs => scs.SchoolClass).WithMany(sc => sc.SchoolClassStudent).HasForeignKey(scs => scs.SchoolClassId),
                r => r.HasOne<Student>(scs => scs.Student).WithMany(s => s.SchoolClassStudent).HasForeignKey(scs => scs.StudentId),
                j =>
                {
                    j.HasKey(scs => new { scs.SchoolClassId, scs.StudentId });
                    j.ToTable("SchoolClassStudent");
                }
            );
    }
}

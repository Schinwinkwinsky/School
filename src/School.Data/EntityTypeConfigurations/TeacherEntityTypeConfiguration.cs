using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Data.EntityTypeConfigurations;

public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasOne<Person>(t => t.Person)
            .WithMany()
            .HasForeignKey(t => t.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

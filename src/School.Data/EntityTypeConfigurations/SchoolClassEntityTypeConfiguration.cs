using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Data.EntityTypeConfigurations
{
    public class SchoolClassEntityTypeConfiguration : IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            builder.HasMany<Student>(sc => sc.Students)
                .WithMany(s => s.SchoolClasses)
                .UsingEntity<SchoolClassStudent>(
                    j => j.HasOne<Student>(scs => scs.Student)
                            .WithMany()
                            .HasForeignKey(scs => scs.StudentId)
                            .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<SchoolClass>(scs => scs.SchoolClass)
                            .WithMany()
                            .HasForeignKey(scs => scs.SchoolClassId)
                            .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasKey(scs => new { scs.SchoolClassId, scs.StudentId })
                );
        }
    }
}

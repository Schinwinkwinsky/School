using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;
using School.Domain.Relations;

namespace School.Data.EntityTypeConfigurations
{
    internal class CourseEntityTypeConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Name).IsRequired();

            builder
                .HasMany<Subject>(c => c.Subjects)
                .WithMany(s => s.Courses)
                .UsingEntity<CourseSubject>(
                    l => l.HasOne<Subject>(cs => cs.Subject).WithMany(s => s.CourseSubject).HasForeignKey(cs => cs.SubjectId),
                    r => r.HasOne<Course>(cs => cs.Course).WithMany(c => c.CourseSubject).HasForeignKey(cs => cs.CourseId),
                    j =>
                    {
                        j.HasKey(cs => new { cs.CourseId, cs.SubjectId });
                        j.ToTable("CourseSubject");
                    }
                );
        }
    }
}

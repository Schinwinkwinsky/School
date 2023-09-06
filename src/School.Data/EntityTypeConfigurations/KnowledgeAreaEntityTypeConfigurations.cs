using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;
using School.Domain.Relations;

namespace School.Data.EntityTypeConfigurations;

public class KnowledgeAreaEntityTypeConfigurations : IEntityTypeConfiguration<KnowledgeArea>
{
    public void Configure(EntityTypeBuilder<KnowledgeArea> builder)
    {
        builder.Property(ka => ka.Name).IsRequired();

        builder
            .HasMany<Subject>(ka => ka.Subjects)
            .WithMany(s => s.KnowledgeAreas)
            .UsingEntity<KnowledgeAreaSubject>(
                l => l.HasOne<Subject>(kas => kas.Subject).WithMany(s => s.KnowledgeAreaSubject).HasForeignKey(kas => kas.SubjectId),
                r => r.HasOne<KnowledgeArea>(kas => kas.KnowledgeArea).WithMany(ka => ka.KnowledgeAreaSubject).HasForeignKey(kas => kas.KnowledgeAreaId),
                j =>
                {
                    j.HasKey(kas => new { kas.KnowledgeAreaId, kas.SubjectId });
                    j.ToTable("KnowledgeAreaSubject");
                }
            );

        builder
            .HasMany<Teacher>(ka => ka.Teachers)
            .WithMany(s => s.KnowledgeAreas)
            .UsingEntity<KnowledgeAreaTeacher>(
                l => l.HasOne<Teacher>(kat => kat.Teacher).WithMany(t => t.KnowledgeAreaTeacher).HasForeignKey(kat => kat.TeacherId),
                r => r.HasOne<KnowledgeArea>(kat => kat.KnowledgeArea).WithMany(ka => ka.KnowledgeAreaTeacher).HasForeignKey(kat => kat.KnowledgeAreaId),
                j =>
                {
                    j.HasKey(kat => new { kat.KnowledgeAreaId, kat.TeacherId });
                    j.ToTable("KnowledgeAreaTeacher");
                }
            );

    }
}

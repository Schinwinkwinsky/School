using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;
using School.Domain.ValueObjects;

namespace School.Data.EntityTypeConfigurations;

public class PersonEntityTypeConfigurations : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(p => p.Name).IsRequired();

        builder.OwnsMany<Address>(p => p.Addresses, opt =>
        {
            opt.ToTable("PersonAddresses");
        });

        builder.OwnsMany<Email>(p => p.Emails, opt =>
        {
            opt.ToTable("PersonEmails");
        });

        builder.OwnsMany<Phone>(p => p.Phones, opt =>
        {
            opt.ToTable("PersonPhones");
        });
    }
}

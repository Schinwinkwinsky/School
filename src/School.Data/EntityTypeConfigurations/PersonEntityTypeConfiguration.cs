using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Data.EntityTypeConfigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Name).IsRequired();

            builder.OwnsMany<Address>(p => p.Addresses);

            builder.OwnsMany<Email>(p => p.Emails);

            builder.OwnsMany<Phone>(p => p.Phones);
        }
    }
}

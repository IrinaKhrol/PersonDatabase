using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonDatabase
{
    public class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(100).HasColumnName("Name");
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100).HasColumnName("Surname");
        }
    }
}

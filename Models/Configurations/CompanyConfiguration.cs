using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // table name

            builder.ToTable("Company");

            // Add primary key

            builder.HasKey(x => x.CompanyId);

            // add constraints

            builder.Property(x => x.Title).IsRequired();
            builder.Property(X => X.Title).HasMaxLength(50);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            builder.HasKey(x => x.Id);

            // add constraints

            builder.Property(x => x.Name).IsRequired();
            builder.Property(X => X.Name).HasMaxLength(50);
        }
    }
}

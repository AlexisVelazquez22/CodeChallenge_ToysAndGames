﻿using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // table name
            builder.ToTable("Product");

            // add primary key
            builder.HasKey(x => x.Product_Id);
            

            // add foreign key
            builder
                .HasOne(x => x.Company)
                .WithMany(x => x.Product)
                .HasForeignKey(x => x.Company_Id);


            // add constraints
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasCheckConstraint("CHK_AgeRestriction", "AgeRestriction > 0 AND AgeRestriction <= 100");
            builder.HasCheckConstraint("CHK_Price", "Price > 0 AND Price <= 1000");
            builder.Property(x => x.Price).HasPrecision(6, 2);
            builder.Property(X => X.Name).HasMaxLength(50);
            builder.Property(X => X.Description).HasMaxLength(100);
        }
    }
}

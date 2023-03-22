using Demo.DataBase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c=>c.Originalprice).IsRequired();
            builder.Property(c=>c.Stock).IsRequired().HasDefaultValue(0);
            builder.Property(c => c.ViewCount).IsRequired().HasDefaultValue(0);
        }
    }
}

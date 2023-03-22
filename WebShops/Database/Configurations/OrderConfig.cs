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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ShipEmail).IsUnicode(false).HasMaxLength(50).IsRequired();
            builder.Property(c =>c.OrderDate);
            builder.Property(c => c.ShipName).HasMaxLength(50).IsRequired();
            builder.Property(c=>c.ShipAddress).HasMaxLength(50).IsRequired();
            builder.Property(c => c.ShipPhoneNumber).HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(c => c.Orders).HasForeignKey(x => x.UserId);
        }
    }
}

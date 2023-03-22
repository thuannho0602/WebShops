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
    public class OrderDatailConfig : IEntityTypeConfiguration<OrderDatail>
    {
        public void Configure(EntityTypeBuilder<OrderDatail> builder)
        {
            builder.ToTable("OrderDatail");
            builder.HasKey(x => new {x.OrderId,x.ProductId});
            builder.HasOne(c=>c.Order).WithMany(c=>c.OrderDatails).HasForeignKey(c=>c.OrderId);
            builder.HasOne(c => c.Product).WithMany(c => c.OrderDatails).HasForeignKey(c => c.ProductId);
        }
    }
}

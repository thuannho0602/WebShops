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
    public class ProductInCategoryConfig : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(pk => new { pk.ProductId, pk.CategoryId });
            builder.ToTable("ProcductInCategory");

            //Xet Khóa Ngoại Product
            builder.HasOne(K => K.Product).WithMany(pk => pk.ProductInCategories)
                .HasForeignKey(pk => pk.ProductId);

            //Xet Khóa Ngoại Category
            builder.HasOne(K => K.Category).WithMany(pk => pk.ProductInCategories)
                .HasForeignKey(pk => pk.CategoryId);
        }
    }
}

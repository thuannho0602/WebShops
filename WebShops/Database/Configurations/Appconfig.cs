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
    public class Appconfig : IEntityTypeConfiguration<Appconfigsa>
    {
        public void Configure(EntityTypeBuilder<Appconfigsa> builder)
        {
            builder.ToTable("AppConfig");
            builder.HasKey(x => x.Value);
            builder.Property(x => x.Value).HasMaxLength(50).IsRequired();


        }
    }
}

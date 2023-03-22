using Demo.DataBase.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Configurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser");
            builder.Property(x=>x.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(x=>x.LastName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.DOB).IsRequired();
           
        }
   
    }
}

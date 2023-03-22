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
    public class CategoryTranslationConfig : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslation");
            builder.HasKey(t => t.Id );

            builder.Property(x => x.Id ).UseIdentityColumn ();
            builder.Property(x => x.Name ).HasMaxLength (100).IsRequired ();
            builder.Property(x=>x.SeoDesCription).HasMaxLength (100).IsRequired (); 
            builder.Property (x => x.SeoTile).HasMaxLength (100).IsRequired ();
            builder.Property(x => x.LanguageId).IsUnicode(false).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Language).WithMany(c => c.CategoryTranslations).HasForeignKey(x => x.LanguageId);
           
        }
    }
}


using Demo.DataBase.Configurations;
using Demo.DataBase.Entity;
using Demo.DataBase.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.EF
{
    public class DemoDbcontext:IdentityDbContext<AppUser,AppRole,Guid>
    {
        public DemoDbcontext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Appconfig());
            modelBuilder.ApplyConfiguration(new CartConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfig());
            modelBuilder.ApplyConfiguration(new ContactConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDatailConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfig()); 
            modelBuilder.ApplyConfiguration(new ProductImageConfig()); 
            modelBuilder.ApplyConfiguration(new ProductTranslationConfig());
            modelBuilder.ApplyConfiguration(new PromotionConfig());
            modelBuilder.ApplyConfiguration(new SlideConfig());
            modelBuilder.ApplyConfiguration(new TranSactionConfig());


            //Uesr,ROle,
            modelBuilder.ApplyConfiguration(new AppUserConfig());
            modelBuilder.ApplyConfiguration(new AppRoleConfig());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("appUserClaim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("appUserRole").HasKey(x => new {x.UserId,x.RoleId});
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("appUserLogin").HasKey(x=>x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("appRoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("appUserToken").HasKey(x => x.UserId);
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
        
        //public DbSet<Appconfigsa> Appconfigs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDatail> OrderDatails { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


    }
}

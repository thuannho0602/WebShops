using Demo.DataBase.Configurations;
using Demo.DataBase.Emum;
using Demo.DataBase.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appconfigsa>().HasData(
               new Appconfigsa() { Key = "Nguyen Minh Thuan", Value = "eeeeeeeeeee" },
               new Appconfigsa() { Key = " Minh Thuan", Value = "ddddddddddddddd" },
               new Appconfigsa() { Key = "Nguyen Minh ", Value = "hhhhhhhhhh" }
                );

            modelBuilder.Entity<Language>().HasData(
               new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
               new Language() { Id = "en", Name = "English", IsDefault = false });
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowonHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,

                },

                 new Category()
                 {
                     Id = 2,
                     IsShowonHome = true,
                     ParentId = null,
                     SortOrder = 1,
                     Status = Status.Active,
                 });
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Áo Nam",
                    LanguageId = "vi",
                    SeoAlias = "Ao-Nam",
                    SeoDesCription = "Sẩn Phẩm Thời Trang Nam ",
                    SeoTile = "Sẩn Phẩm Thời Trang Nam"
                },
                 new CategoryTranslation()
                 {
                     Id = 2,
                     CategoryId = 2,
                     Name = "Men-Shirt",
                     LanguageId = "en",
                     SeoAlias = "Men-Shirt",
                     SeoDesCription = "Men's Fashion Products ",
                     SeoTile = "Men's Fashion Products"
                 }

                );
            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = 1,
                   DateCreacted = DateTime.Now,
                   Originalprice = 10000,
                   Price = 2000,
                   Stock = 0,
                   ViewCount = 0,
               },
               new Product()
               {
                   Id = 2,
                   DateCreacted = DateTime.Now,
                   Originalprice = 10000,
                   Price = 2000,
                   Stock = 0,
                   ViewCount = 0,
               }
               );
            modelBuilder.Entity<ProductTranslation>().HasData(
                  new ProductTranslation()
                  {
                      Id = 1,
                      ProductId = 1,
                      Name = "Áo Sơ Mi Nam Trắng Minh Thuận",
                      LanguageId = "vi",
                      SeoAlias = "ao-so-mi-nam-trang-minh-thuan",
                      SeoDescription = "Áo Sơ Mi Nam Trắng Minh Thuận ",
                      SeoTitle = "Áo Sơ Mi Nam Trắng Minh Thuận",
                      Description = "Áo Sơ Mi Nam Trắng Minh Thuận",
                      Details = "Áo Sơ Mi Nam Trắng Minh Thuận"
                  },
                  new ProductTranslation()
                  {
                      Id = 2,
                      ProductId = 2,
                      Name = "Minh Thuan Men's White Shirt",
                      LanguageId = "en",
                      SeoAlias = "minh-thuan-men's-white-shirt",
                      SeoDescription = "Minh Thuan Men's White Shirt ",
                      SeoTitle = "Minh Thuan Men's White Shirt",
                      Description = "Minh Thuan Men's White Shirt",
                      Details = "Minh Thuan Men's White Shirt"
                  }
                );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory()
                {
                    ProductId = 1,
                    CategoryId = 1,
                }

                );

            //User Và Role
            var roleId = new Guid("30C3C812-22C7-41EE-8B82-B6D2EA0AE6CD");
            var adminId = new Guid("1BF6041A-0963-4EB7-BBDC-0AB25B0E301D");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "thuannho0602@gmail.com",
                NormalizedEmail = "thuannho0602@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Thuan123@"),
                SecurityStamp = string.Empty,
                FirstName = "THuan",
                LastName = "Nguyen",
                DOB = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<Slide>().HasData(
              new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
              new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
              new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
              new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
              new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
              new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
              );





        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShops.Database.Migrations
{
    public partial class ShopWebEF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppConfig",
                columns: new[] { "Value", "Key" },
                values: new object[,]
                {
                    { "ddddddddddddddd", " Minh Thuan" },
                    { "eeeeeeeeeee", "Nguyen Minh Thuan" },
                    { "hhhhhhhhhh", "Nguyen Minh " }
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"), "29541235-268d-469c-8592-407ee955f10e", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d"), 0, "86ebae52-a3ad-49f0-ad85-9f6454c96565", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "thuannho0602@gmail.com", true, "THuan", "Nguyen", false, null, "thuannho0602@gmail.com", "admin", "AQAAAAEAACcQAAAAEBHgfIhczYlCJbruO4JPkjOgzppZvvxNLbLPErF7ER998vFt7BuDhUpoWnWksR7j7Q==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "IsShowonHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "en", false, "English" },
                    { "vi", true, "Tiếng Việt" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "DateCreacted", "IsFeaatured", "Originalprice", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 27, 10, 17, 24, 703, DateTimeKind.Local).AddTicks(3436), false, 10000m, 2000m },
                    { 2, new DateTime(2023, 3, 27, 10, 17, 24, 703, DateTimeKind.Local).AddTicks(3448), false, 10000m, 2000m }
                });

            migrationBuilder.InsertData(
                table: "Slide",
                columns: new[] { "Id", "Description", "Image", "Name", "SortOrder", "Status", "Url" },
                values: new object[,]
                {
                    { 1, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/1.png", "Second Thumbnail label", 1, 1, "#" },
                    { 2, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/2.png", "Second Thumbnail label", 2, 1, "#" },
                    { 3, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/3.png", "Second Thumbnail label", 3, 1, "#" },
                    { 4, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/4.png", "Second Thumbnail label", 4, 1, "#" },
                    { 5, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/5.png", "Second Thumbnail label", 5, 1, "#" },
                    { 6, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/6.png", "Second Thumbnail label", 6, 1, "#" }
                });

            migrationBuilder.InsertData(
                table: "appUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"), new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d") });

            migrationBuilder.InsertData(
                table: "CategoryTranslation",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDesCription", "SeoTile" },
                values: new object[,]
                {
                    { 1, 1, "vi", "Áo Nam", "Ao-Nam", "Sẩn Phẩm Thời Trang Nam ", "Sẩn Phẩm Thời Trang Nam" },
                    { 2, 2, "en", "Men-Shirt", "Men-Shirt", "Men's Fashion Products ", "Men's Fashion Products" }
                });

            migrationBuilder.InsertData(
                table: "ProcductInCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslation",
                columns: new[] { "Id", "Description", "Details", "LanguageId", "Name", "ProductId", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Áo Sơ Mi Nam Trắng Minh Thuận", "Áo Sơ Mi Nam Trắng Minh Thuận", "vi", "Áo Sơ Mi Nam Trắng Minh Thuận", 1, "ao-so-mi-nam-trang-minh-thuan", "Áo Sơ Mi Nam Trắng Minh Thuận ", "Áo Sơ Mi Nam Trắng Minh Thuận" },
                    { 2, "Minh Thuan Men's White Shirt", "Minh Thuan Men's White Shirt", "en", "Minh Thuan Men's White Shirt", 2, "minh-thuan-men's-white-shirt", "Minh Thuan Men's White Shirt ", "Minh Thuan Men's White Shirt" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Value",
                keyValue: "ddddddddddddddd");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Value",
                keyValue: "eeeeeeeeeee");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Value",
                keyValue: "hhhhhhhhhh");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d"));

            migrationBuilder.DeleteData(
                table: "CategoryTranslation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProcductInCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "appUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"), new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d") });

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "en");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "vi");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

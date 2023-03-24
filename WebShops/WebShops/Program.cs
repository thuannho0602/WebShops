using Deme.Unitities.Constast;
using Demo.DataBase.EF;
using Demo.DataBase.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop.Application.Catalog.Productt;
using WebShop.Application.Common;
using WebShop.Application.System.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Ket Nối Database
builder.Services.AddDbContext<DemoDbcontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstanst.MainConnectionString));


});
 // Xet JWT Asp.Net
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<DemoDbcontext>()
    .AddDefaultTokenProviders();
    
    
//Declare DI 


builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<IPublicProductService, PublicProductService>();
builder.Services.AddTransient<IManageProductService, ManageProductServise>();
<<<<<<< HEAD
=======
builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>(); 
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<IUserService,UserService>();
>>>>>>> add_images

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

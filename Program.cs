//using AlGallery.Data;
//using AlGallery.Repositories;
//using AlGallery.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using E_Commerce_MVC.Repositories;

//namespace AlGallery
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.
//            builder.Services.AddControllersWithViews();

//            builder.Services.AddDbContext<AlGalleryDBContext>(options =>
//                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));


//            //builder.Services.AddIdentity<User, IdentityRole>(options =>
//            //{
//            //    options.User.RequireUniqueEmail = true;
//            //    options.Password.RequireNonAlphanumeric = false;
//            //    options.Password.RequireDigit = false;
//            //    options.Password.RequireUppercase = false;
//            //    options.Password.RequireLowercase = false;
//            //    options.Password.RequiredLength = 5;

//            //}).AddEntityFrameworkStores<AlGalleryDBContext>();


//            builder.Services.AddScoped<IProductRepo, ProductRepo>();
//            builder.Services.AddScoped<ICartItemRepo, CartItemRepo>();
//            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

//            // Add services to the container.
//            builder.Services.AddControllersWithViews();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Home}/{action=Home}/{id?}");

//            app.Run();
//        }
//    }
//}


using AlGallery.Data;
using AlGallery.Repositories;
using AlGallery.Interfaces;
using Microsoft.EntityFrameworkCore;
using E_Commerce_MVC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AlGalleryDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<ICartItemRepo, CartItemRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();


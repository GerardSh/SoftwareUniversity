using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WarehouseApp.Data;

namespace WarehouseApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            //var connectionString = builder.Configuration.GetConnectionString("WarehouseDbConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //builder.Services.AddDbContext<WarehouseDbContext>(options =>
            //    options.UseSqlServer(connectionString));
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            //builder.Services.AddControllersWithViews();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseMigrationsEndPoint();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            // Ensure the database is created on startup

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapRazorPages();

            //app.Run();

            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            //var connectionString = builder.Configuration.GetConnectionString("WarehouseDbConnection") ??
            //    throw new InvalidOperationException("Connection string 'WarehouseDbConnection' not found.");

            //// Register your main DbContext for the application data
            //builder.Services.AddDbContext<WarehouseDbContext>(options =>
            //    options.UseSqlServer(connectionString));

            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //// Register MVC Controllers and Views
            //builder.Services.AddControllersWithViews();
            //builder.Services.AddRazorPages();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseMigrationsEndPoint();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapRazorPages();

            //app.Run();
        }
    }
}

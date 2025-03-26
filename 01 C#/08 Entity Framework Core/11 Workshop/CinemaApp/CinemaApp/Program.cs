using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Data.Seeding;
using CinemaApp.Data.Seeding.Interfaces;
using CinemaApp.Data.Utilities;
using CinemaApp.Data.Utilities.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("CinemaDbConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IValidator, EntityValidator>();
builder.Services.AddSingleton<IXmlHelper, XmlHelper>();
builder.Services.AddScoped<IDbSeeder, ApplicationDbContextSeeder>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;

        options.Password.RequireDigit = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 3;
    })
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<CinemaDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

if (app.Environment.IsDevelopment())
{
    using IServiceScope scope = app.Services.CreateScope();
    IServiceProvider services = scope.ServiceProvider;

    IDbSeeder dataProcessor = services.GetRequiredService<IDbSeeder>();
    await dataProcessor.SeedData();
}

app.Run();

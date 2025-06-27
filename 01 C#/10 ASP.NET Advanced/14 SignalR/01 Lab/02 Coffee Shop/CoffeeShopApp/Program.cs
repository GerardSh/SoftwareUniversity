using CoffeeShopApp.Hubs;
using CoffeeShopApp.Services;
using CoffeeShopApp.Services.Contracts;

namespace CoffeeShopApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSignalR().AddMessagePackProtocol();

            builder.Services.AddSingleton<IOrderService, OrderService>();

            builder.Services.AddSingleton<Random>();

            builder.Services.AddSingleton<IList<int>>(new List<int>());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // For API controllers
                endpoints.MapHub<CoffeeHub>("/coffeehub"); // Map SignalR hub
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

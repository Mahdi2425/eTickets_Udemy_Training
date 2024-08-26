using Azure;
using eTickets.Data;
using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Models;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(Options => Options.UseSqlServer("Data Source=(Local);Initial Catalog=CourseProject;Integrated Security=True;Trust Server Certificate=True;"));
        builder.Services.AddScoped<IActorsService, ActorsService>();    
        builder.Services.AddScoped<IProducersService, ProducersService>();
        builder.Services.AddScoped<ICinemasServices,CinemasServices>();
        builder.Services.AddScoped<IMoviesService,MoviesService>();
        builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
        builder.Services.AddScoped<IOrdersService,OrdersServices>();    
        builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
        builder.Services.AddSession();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        builder.Services.AddMemoryCache();
        builder.Services.AddSession();
        builder.Services.AddAuthentication(Options =>
        {
            Options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        });
        builder.Services.Configure<IdentityOptions>(Options =>
        {
            Options.Password.RequiredLength = 6;
            Options.Password.RequireLowercase = false;
            Options.Password.RequireNonAlphanumeric = false;
            Options.Password.RequireUppercase = false;
            Options.Password.RequireDigit = false;
        });
        WebApplication app = builder.Build();




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
        app.UseSession();   
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        AppDbInitilizer.Seed(app);
        AppDbInitilizer.SeedUsersandRolesAsync(app).Wait();    
        app.Run();
    }
}
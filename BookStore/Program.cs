using System.Security.Claims;
using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizePage("/Admin");
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/accessdenied";
                });

            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString: "DefaultConnection"));

            var app = builder.Build();

            app.UseAuthentication();
            //var scope = app.Services.CreateScope();
            //var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllers();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
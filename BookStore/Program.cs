using BookStore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                options.Conventions.AuthorizeAreaFolder("Admin", "/Pages/", "Admin");
                options.Conventions.AuthorizeAreaFolder("User", "/Pages/", "Admin, User");
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/accessdenied";
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", p=>p.RequireRole("Admin"));
                options.AddPolicy("User", p=>p.RequireRole("User"));
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString: "DefaultConnection"));

            var app = builder.Build();

            app.UseAuthentication();

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
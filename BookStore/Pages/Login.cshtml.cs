using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Authentication;

namespace BookStore.Pages
{
    [IgnoreAntiforgeryToken]
    public class LoginModel : PageModel
    {

        public ApplicationDbContext _concext;
        public LoginModel(ApplicationDbContext context) => _concext = context;

        public void OnGet()
        {

        }

        public IActionResult OnPost(string? returnUrl)
        {
            var ctx = HttpContext.Request.HttpContext;
            var form = ctx.Request.Form;
            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
                return BadRequest("Email и/или пароль не установлены");
            string email = form["email"];
            string password = form["password"];
            if (email == string.Empty || password == string.Empty)
                return BadRequest("Введите email и пароль");
            Models.Entities.User user = _concext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user is null)
                return NotFound("Некорректный email или пароль");
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            ctx.SignInAsync(claimsPrincipal);
            if (claimsPrincipal.IsInRole("User"))
                return Redirect(returnUrl ?? "~/user");
            if (claimsPrincipal.IsInRole("Admin"))
                return Redirect(returnUrl ?? "~/Admin");
            return Redirect(returnUrl ?? "/");
        }
    }
}
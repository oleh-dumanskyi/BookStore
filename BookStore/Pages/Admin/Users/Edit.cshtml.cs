using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
[IgnoreAntiforgeryToken]
public class EditModel : PageModel
{
    public EditModel(ApplicationDbContext context)
    {
        Context = context;
    }

    public ApplicationDbContext Context { get; set; }

    [BindProperty] public Models.Entities.User? User { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        User = Context.Users.First(u => u.Id == id);
        if (User == null) return NotFound();
        return Page();
    }

    public IActionResult OnPost()
    {
        if (User.Email == null || User.Password == null || User.Name == null || User.Role == null)
            return RedirectToPage("");
        var user = (from u in Context.Users
            where u.Id == User.Id
            select u).First();
        user.Email = User.Email;
        user.Password = User.Password;
        user.Name = User.Name;
        user.Role.Name = User.Role.Name;
        Context.SaveChanges();
        return RedirectToPage("/Admin/Users/Index");
    }
}
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
[IgnoreAntiforgeryToken]
public class CreateModel : PageModel
{
    public CreateModel(ApplicationDbContext context)
    {
        Context = context;
    }

    public ApplicationDbContext Context { get; set; }

    [BindProperty] public Models.Entities.User? User { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (User.Email == null || User.Password == null || User.Name == null || User.Role == null)
            return BadRequest("Incorrect data input");
        Context.Users.Add(User);
        Context.SaveChanges();
        return RedirectToPage("/Admin/Users/Index");
    }
}
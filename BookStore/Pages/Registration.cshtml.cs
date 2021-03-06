using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages;

[IgnoreAntiforgeryToken]
public class RegistrationModel : PageModel
{
    public RegistrationModel(ApplicationDbContext context)
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
        Context.Users.Add(User);
        Context.SaveChanges();
        return RedirectToPage("/Index");
    }
}
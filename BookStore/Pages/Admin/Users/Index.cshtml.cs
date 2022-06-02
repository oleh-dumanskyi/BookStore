using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin.Users;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    public IndexModel(ApplicationDbContext context)
    {
        Context = context;
    }

    public ApplicationDbContext Context { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPostDelete(int? id)
    {
        var user = Context.Users.Find(id);
        if (user != null)
        {
            Context.Users.Remove(user);
            Context.SaveChanges();
        }

        return RedirectToPage("/Admin/Users/Index");
    }
}
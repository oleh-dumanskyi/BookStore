using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin.Books;

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
        var book = Context.Books.Find(id);
        if (book != null)
        {
            Context.Books.Remove(book);
            Context.SaveChanges();
        }

        return RedirectToPage("/Admin/Books/Index");
    }
}
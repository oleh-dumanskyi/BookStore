using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin.Books
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        public ApplicationDbContext Context { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            Context = context;
        }

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
}

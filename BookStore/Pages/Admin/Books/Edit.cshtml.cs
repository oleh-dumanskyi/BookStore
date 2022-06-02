using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin.Books
{
    [Authorize(Roles = "Admin")]
    [IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        public ApplicationDbContext Context { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            Context = context;
        }
        [BindProperty]
        public Book? Book { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = Context.Books.First(b=>b.Id == id);
            if (Book == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Book.Title == null || Book.Author == null || Book.Language == null) return RedirectToPage("");
            Context.Books.Update(Book!);
            Context.SaveChanges();
            return RedirectToPage("/Admin/Books/Index");
        }
    }
}

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
        public ApplicationDbContext _context { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book? Book { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _context.Books.First(b=>b.Id == id);
            if (Book == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Book.Title == null || Book.Author == null || Book.Language == null) return RedirectToPage("");
            _context.Books.Update(Book!);
            _context.SaveChanges();
            return RedirectToPage("/Admin/Books/Index");
        }
    }
}

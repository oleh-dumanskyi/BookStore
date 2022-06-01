using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin.Books
{
    [Authorize(Roles = "Admin")]
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        public ApplicationDbContext _context { get; set; }
        [BindProperty]
        public Book? Book { get; set; } = new ();

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Book.Title == null || Book.Author == null || Book.Language == null)
                return BadRequest("Incorrect data input");
            _context.Books.Add(Book);
            _context.SaveChanges();
            return RedirectToAction("Admin/Books/Index");
        }
    }
}

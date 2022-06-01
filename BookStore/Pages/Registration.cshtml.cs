using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStore.Models.Entities;

namespace BookStore.Pages
{
    [IgnoreAntiforgeryToken]
    public class RegistrationModel : PageModel
    {
        public ApplicationDbContext _context { get; set; }
        [BindProperty]
        public Models.Entities.User? User { get; set; } = new ();
        public RegistrationModel(ApplicationDbContext context) => _context = context;
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _context.Users.Add(User);
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}

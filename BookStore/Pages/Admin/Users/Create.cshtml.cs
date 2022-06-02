using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        public ApplicationDbContext _context { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Models.Entities.User? User { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (User.Email == null || User.Password == null || User.Name == null || User.Role == null)
                return BadRequest("Incorrect data input");
            _context.Users.Add(User);
            _context.SaveChanges();
            return RedirectToPage("/Admin/Users/Index");
        }
    }
}

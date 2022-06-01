using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.User
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        public ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;
        public void OnGet()
        {
        }

        public IActionResult OnPost(int? bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            var currentUser = _context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            if (!currentUser.ShoppingCart.Contains(book))
            {
                currentUser.ShoppingCart.Add(book);
                _context.SaveChanges();
            }
            return RedirectToPage("/User/Index");
        }
    }
}
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.User
{
    public class ShoppingCartModel : PageModel
    {
        public ApplicationDbContext _context;
        public ShoppingCartModel(ApplicationDbContext context) => _context = context;
        public void OnGet()
        {
        }
    }
}

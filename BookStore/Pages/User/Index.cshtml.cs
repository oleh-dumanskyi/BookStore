using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.User
{
    public class IndexModel : PageModel
    {
        public ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;
        public void OnGet()
        {
        }
    }
}
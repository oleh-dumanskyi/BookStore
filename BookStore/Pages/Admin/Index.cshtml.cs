using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        public ApplicationDbContext _context { get; set; }
        public IndexModel(ApplicationDbContext context) => _context = context;

        public void OnGet()
        {
        }
    }
}
using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class IndexModel : PageModel
    {
        public ApplicationDbContext Context;

        public IndexModel(ApplicationDbContext context)
        {
            Context = context;
        } 
        public void OnGet()
        {
        }
    }
}
using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Pages.User
{
    [Authorize(Roles = "User, Admin")]
    public class ShoppingCartModel : PageModel
    {
        public ApplicationDbContext _context;
        public List<Book> Books { get; set; }
        public ShoppingCartModel(ApplicationDbContext context) => _context = context;
        public void OnGet()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            var query = 
                from b in _context.Books
                join bsc in _context.BookShoppingCarts on b.Id equals bsc.BookId
                join sc in _context.ShoppingCarts on bsc.ShoppingCartId equals sc.Id
                join u in _context.Users on sc.UserId equals u.Id
                where u.Id == currentUser.Id
                select b;
            Books = query.ToList();

        }
        public IActionResult OnPostDelete(int? id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                var currentUser = _context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
                var query =
                    from b in _context.Books
                    join bsc in _context.BookShoppingCarts on b.Id equals bsc.BookId
                    join sc in _context.ShoppingCarts on bsc.ShoppingCartId equals sc.Id
                    join u in _context.Users on sc.UserId equals u.Id
                    where bsc.BookId == id && u.Id == currentUser.Id
                    select bsc;
                _context.BookShoppingCarts.Remove(query.First());
                _context.SaveChanges();
                return RedirectToPage("/User/Shoppingcart");
            }
            return BadRequest("Error");
        }
    }
}

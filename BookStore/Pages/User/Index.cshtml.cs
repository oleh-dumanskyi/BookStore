using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            var cart = _context.ShoppingCarts.FirstOrDefault(c => c.UserId == currentUser.Id);
            var booksOfUser = _context.Books.FromSqlInterpolated($"SELECT Books.Id, Books.Title, Books.Author, Books.[Language], Books.Pages, Books.Genre, Books.Price, Books.ShoppingCartId FROM Books\r\nJOIN dbo.BookShoppingCart ON BookShoppingCart.BooksId = Books.Id\r\nJOIN ShoppingCarts ON ShoppingCarts.Id = BookShoppingCart.ShoppingCartsId\r\nJOIN [Users] ON [Users].Id = ShoppingCarts.UserId\r\nWHERE [Users].Id = {currentUser.Id}").ToList();
            if (!booksOfUser.Contains(book))
            {
                cart.Books.Add(book);
                book.ShoppingCarts.Add(cart);
                _context.SaveChanges();
            }
            return RedirectToPage("/User/Index");
        }
    }
}
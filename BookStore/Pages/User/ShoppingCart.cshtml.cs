using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Pages.User
{
    public class ShoppingCartModel : PageModel
    {
        public ApplicationDbContext _context;
        public List<Book> Books { get; set; }
        public ShoppingCartModel(ApplicationDbContext context) => _context = context;
        public void OnGet()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            Books = _context.Books.FromSqlInterpolated($"SELECT Books.Id, Books.Title, Books.Author, Books.[Language], Books.Pages, Books.Genre, Books.Price, Books.ShoppingCartId FROM Books\r\nJOIN dbo.BookShoppingCart ON BookShoppingCart.BooksId = Books.Id\r\nJOIN ShoppingCarts ON ShoppingCarts.Id = BookShoppingCart.ShoppingCartsId\r\nJOIN [Users] ON [Users].Id = ShoppingCarts.UserId\r\nWHERE [Users].Id = {currentUser.Id}").ToList();
        }
    }
}

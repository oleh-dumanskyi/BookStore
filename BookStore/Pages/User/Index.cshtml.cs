using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Pages.User
{
    [IgnoreAntiforgeryToken]
    [Authorize(Roles = "User, Admin")]
    public class IndexModel : PageModel
    {
        public ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;
        public List<Book> BooksInCart { get; set; }

        public void OnGet()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            var booksOfUser =
                from b in _context.Books
                join bsc in _context.BookShoppingCarts on b.Id equals bsc.BookId
                join sc in _context.ShoppingCarts on bsc.ShoppingCartId equals sc.Id
                join u in _context.Users on sc.UserId equals u.Id
                where u.Id == currentUser.Id
                select b;
            BooksInCart = booksOfUser.ToList();
        }

        public IActionResult OnPost(int? Id)
        {
            var book = _context.Books.First(b => b.Id == Id);
            if (book is null)
                return NotFound("Book not found");
            var currentUser = _context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            var cart = _context.ShoppingCarts.FirstOrDefault(c => c.UserId == currentUser.Id);

            var booksOfUser =
                from b in _context.Books
                join bsc in _context.BookShoppingCarts on b.Id equals bsc.BookId
                join sc in _context.ShoppingCarts on bsc.ShoppingCartId equals sc.Id
                join u in _context.Users on sc.UserId equals u.Id
                where u.Id == currentUser.Id && bsc.BookId == Id
                select b;
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
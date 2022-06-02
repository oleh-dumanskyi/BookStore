using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.User
{
    [IgnoreAntiforgeryToken]
    [Authorize(Roles = "User, Admin")]
    public class IndexModel : PageModel
    {
        public ApplicationDbContext Context;
        public IndexModel(ApplicationDbContext context) => Context = context;
        public List<Book> BooksInCart { get; set; }

        public void OnGet()
        {
            var currentUser = Context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            var booksOfUser =
                from b in Context.Books
                join bsc in Context.BookShoppingCarts on b.Id equals bsc.BookId
                join sc in Context.ShoppingCarts on bsc.ShoppingCartId equals sc.Id
                join u in Context.Users on sc.UserId equals u.Id
                where u.Id == currentUser.Id
                select b;
            BooksInCart = booksOfUser.ToList();
        }

        public IActionResult OnPost(int? id)
        {
            var book = Context.Books.First(b => b.Id == id);
            if (book is null)
                return NotFound("Book not found");
            var currentUser = Context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            var cart = Context.ShoppingCarts.FirstOrDefault(c => c.UserId == currentUser.Id);

            var booksOfUser =
                from b in Context.Books
                join bsc in Context.BookShoppingCarts on b.Id equals bsc.BookId
                join sc in Context.ShoppingCarts on bsc.ShoppingCartId equals sc.Id
                join u in Context.Users on sc.UserId equals u.Id
                where u.Id == currentUser.Id && bsc.BookId == id
                select b;
            if (!booksOfUser.Contains(book))
            {
                cart.Books.Add(book);
                book.ShoppingCarts.Add(cart);
                Context.SaveChanges();
            }
            return RedirectToPage("/User/Index");
        }
    }
}
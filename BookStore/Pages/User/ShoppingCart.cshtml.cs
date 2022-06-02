using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.User
{
    [Authorize(Roles = "User, Admin")]
    public class ShoppingCartModel : PageModel
    {
        public ApplicationDbContext Context;
        public List<Book> Books { get; set; }
        public ShoppingCartModel(ApplicationDbContext context) => Context = context;
        public void OnGet()
        {
            var currentUser = Context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            var query = 
                from b in Context.Books
                join bsc in Context.BookShoppingCarts on b.Id equals bsc.BookId
                join sc in Context.ShoppingCarts on bsc.ShoppingCartId equals sc.Id
                join u in Context.Users on sc.UserId equals u.Id
                where u.Id == currentUser.Id
                select b;
            Books = query.ToList();

        }
        public IActionResult OnPostDelete(int? id)
        {
            var book = Context.Books.Find(id);
            if (book != null)
            {
                var currentUser = Context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
                var query =
                    from b in Context.Books
                    join bsc in Context.BookShoppingCarts on b.Id equals bsc.BookId
                    join sc in Context.ShoppingCarts on bsc.ShoppingCartId equals sc.Id
                    join u in Context.Users on sc.UserId equals u.Id
                    where bsc.BookId == id && u.Id == currentUser.Id
                    select bsc;
                Context.BookShoppingCarts.Remove(query.First());
                Context.SaveChanges();
                return RedirectToPage("/User/Shoppingcart");
            }
            return BadRequest("Error");
        }
    }
}

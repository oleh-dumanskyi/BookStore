using BookStore.Models;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class IndexModel : PageModel
    {
        public ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
            /*_context.Books.Add(new Book()
            {
                Author = "Leo Tolstoy",
                Genre = "Fiction",
                Language = "Russian",
                Pages = 1225,
                Title = "War and peace",
                Price = 20
            });
            _context.Books.Add(new Book()
            {
                Author = "Enthony Bivor",
                Genre = "Documentary",
                Language = "English",
                Pages = 815,
                Title = "THE SECOND WORLD WAR",
                Price = 16
            });
            _context.Books.Add(new Book()
            {
                Author = "Jan Smith",
                Genre = "Art",
                Language = "Ukrainian",
                Pages = 512,
                Title = "Short history of art",
                Price = 10
            });
            _context.Users.Add(new Models.Entities.User() { Name = "Oleh", Email = "111@gmail.com", Password = "111", Role = new Role("Admin")});
            _context.Users.Add(new Models.Entities.User() { Name = "Ivan", Email = "222@gmail.com", Password = "222", Role = new Role("User")});
            _context.Users.Add(new Models.Entities.User() { Name = "Pavel", Email = "333@gmail.com", Password = "333", Role = new Role("User")});
            _context.SaveChanges();*/
        } 
        public void OnGet()
        {
        }
    }
}
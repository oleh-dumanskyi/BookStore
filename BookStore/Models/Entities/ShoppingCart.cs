using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Entities
{
    public class ShoppingCart
    {
        [Required]
        public List<Book> Books { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Entities
{
    public class Book
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Язык")]
        public string Language { get; set; }
        [Required]
        [Display(Name = "Страницы")]
        public int Pages { get; set; }
        [Required]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }
        [Required]
        [Display(Name = "Стоимость")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Некорректная стоимость")]
        public decimal Price { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; } = new();
        public List<BookShoppingCart> BookShoppingCarts { get; set; } = new();
        public int ShoppingCartId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models.Entities
{
    public class Book
    {
        [Required]
        [Key]
        public long Id { get; set; }
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

        public List<User> Users { get; set; } = new List<User>();
    }
}

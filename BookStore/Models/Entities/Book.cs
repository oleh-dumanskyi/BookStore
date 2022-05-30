using System.ComponentModel.DataAnnotations;
using BookStore.Models.Enums;

namespace BookStore.Models.Entities
{
    public class Book
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Автор")]
        public List<string> Authors { get; set; }
        [Required]
        [Display(Name = "Язык")]
        public Language Language { get; set; }
        [Required]
        [Display(Name = "Страницы")]
        public int Pages { get; set; }
        [Required]
        [Display(Name = "Жанр")]
        public List<Genre> Genres { get; set; }
        [Required]
        [Display(Name = "Стоимость")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Некорректная стоимость")]
        public decimal Price { get; set; }
    }
}

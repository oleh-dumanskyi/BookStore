using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        ShoppingCart Cart { get; set; }
        [Required]
        public bool IsAdmin { get; set; } = false;
    }
}

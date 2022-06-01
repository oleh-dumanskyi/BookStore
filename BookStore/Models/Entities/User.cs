using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Entities
{
    public class User
    {
        [Required]
        [Key]
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

        [Required] public List<Book> ShoppingCart { get; set; } = new List<Book>();

        [Required]
        public Role Role { get; set; }
        
    }
}

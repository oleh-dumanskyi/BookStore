namespace BookStore.Models.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

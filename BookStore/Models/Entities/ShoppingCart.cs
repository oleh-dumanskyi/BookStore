namespace BookStore.Models.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public List<Book> Books { get; set; } = new();
    public List<BookShoppingCart> BookShoppingCarts { get; set; } = new();
    public int UserId { get; set; }
    public User? User { get; set; }
}
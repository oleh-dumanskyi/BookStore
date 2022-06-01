namespace BookStore.Models.Entities
{
    public class BookShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}

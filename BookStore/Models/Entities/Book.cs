using BookStore.Models.Enums;

namespace BookStore.Models.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public Language Language { get; set; }
        public int Pages { get; set; }
        public List<Genre> Genres { get; set; }
        public decimal Price { get; set; }
    }
}

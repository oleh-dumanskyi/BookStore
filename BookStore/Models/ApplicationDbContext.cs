using BookStore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<BookShoppingCart> BookShoppingCarts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<User>()
            .HasOne(p => p.ShoppingCart).WithOne(p => p.User).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ShoppingCart>()
            .HasMany(p => p.Books).WithMany(b => b.ShoppingCarts)
            .UsingEntity<BookShoppingCart>(
                b => b
                    .HasOne(u => u.ShoppingCart)
                    .WithMany(b => b.BookShoppingCarts)
                    .HasForeignKey(k => k.ShoppingCartId)
            );
        modelBuilder.Entity<Book>()
            .HasMany(b => b.ShoppingCarts).WithMany(c => c.Books)
            .UsingEntity<BookShoppingCart>(
                b => b
                    .HasOne(b => b.Book)
                    .WithMany(b => b.BookShoppingCarts)
                    .HasForeignKey(k => k.BookId)
            );
    }
}
using BookStore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
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
                .HasOne(p => p.ShoppingCart).WithOne(p => p.User);
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(p => p.Books).WithMany(b => b.ShoppingCarts);
            modelBuilder.Entity<Book>()
                .HasMany(b => b.ShoppingCarts).WithMany(c => c.Books);
        }
    }
}

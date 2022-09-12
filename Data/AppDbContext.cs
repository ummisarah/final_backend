using final_project.Models;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>
        options)
            : base(options)
            {
            }

            public DbSet<User> Users {get; set;}
            public DbSet<Product> Products {get; set;}
            public DbSet<Address> Addresses {get; set;}
            public DbSet<Cart> Carts {get; set;}
            public DbSet<Wishlist> Wishlists {get; set;}
            public DbSet<Token> Tokens {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.CartModel;
using final_project.Models.WishlistModel;
using Microsoft.EntityFrameworkCore;
using final_project.Models;

namespace final_project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // //base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Skill>().HasData(
            //     new Skill {Id = 1, Name = "Fireball", Damage = 30},
            //     new Skill {Id = 2, Name = "Frenzy", Damage = 20},
            //     new Skill {Id = 3, Name = "Blizzard", Damage = 50}
            // );
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Token> Tokens {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Cart> Carts {get; set;}
        public DbSet<CartItem> CartItems {get; set;}
        public DbSet<Wishlist> Wishlists {get; set;}
        public DbSet<WishlistItem> WishlistItems {get; set;}
    }
}
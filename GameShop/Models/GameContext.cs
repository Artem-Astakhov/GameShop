using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class GameContext:DbContext
    {
        public GameContext(DbContextOptions<GameContext> options):base(options)
        {
            Database.EnsureCreated();          
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admin { get; set; }
     }
}

using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace App.Persistence
{
    public class AppContext : DbContext, IUsersContext, IProductsContext, IOrdersContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

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
            //Database.EnsureCreated();
            InitDbInMemory();
        }

        static bool isInit = false;
        public void InitDbInMemory()
        {
            if (!Database.IsInMemory() || isInit)
                return;

            Database.EnsureCreated();

            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "Продукт 1",
                    Price = 100
                }, new Product()
                {
                    Name = "Продукт 2",
                    Price = 200
                }, new Product()
                {
                    Name = "Продукт 3",
                    Price = 300
                }
            };

            Products.AddRange();

            var admin = new User()
            {
                RefreshToken = "xdb04oV0gHEgmGMvWXs7I4k4dMKZTwlZjNJoyUH7af4FA+dQsomacLIQcDGpJyuhNm6XqewoChBgpI2R2e9v0Q==",
                IsAdmin = true
            };

            Users.Add(admin);

            // получение id для продуктов и пользователя
            SaveChanges();

            Orders.AddRange(new Order()
            {
                User = admin,
                Products = products,
            });

            SaveChanges();

            isInit = true;
        }
    }
}

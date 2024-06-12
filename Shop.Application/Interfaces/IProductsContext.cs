using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.Application.Interfaces
{
    public interface IProductsContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}

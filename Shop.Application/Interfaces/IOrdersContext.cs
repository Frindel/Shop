using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.Application.Interfaces
{
    public interface IOrdersContext
    {
        DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}

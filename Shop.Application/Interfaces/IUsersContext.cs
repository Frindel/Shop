using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.Application.Interfaces
{
    public interface IUsersContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}

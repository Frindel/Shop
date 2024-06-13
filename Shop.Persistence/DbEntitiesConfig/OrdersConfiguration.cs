using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;

namespace Shop.Persistence.DbEntitiesConfig
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.Products).WithMany(p => p.Orders);

            //builder.HasMany(n => n.Categories).WithMany(c => c.Notes).UsingEntity(j => j.ToTable("NoteCategories"));
        }
    }
}

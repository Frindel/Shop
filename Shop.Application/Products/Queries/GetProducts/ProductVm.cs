using Shop.Application.Common.Mappings;
using Shop.Domain;

namespace Shop.Application.Products.Queries.GetProducts
{
    public class OrderVm : MappingBase<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}

using Shop.Application.Common.Mappings;
using Shop.Domain;

namespace Shop.Application.Products.Queries.GetProducts
{
    public class ProductVm : MappingBase<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}

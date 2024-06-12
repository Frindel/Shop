using MediatR;

namespace Shop.Application.Categories.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductVm>
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}

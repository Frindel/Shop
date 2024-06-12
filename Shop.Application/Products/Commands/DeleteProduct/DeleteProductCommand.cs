using MediatR;

namespace Shop.Application.Categories.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}

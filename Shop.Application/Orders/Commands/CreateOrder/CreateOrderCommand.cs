using MediatR;

namespace Shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderVm>
    {
        public int UserId { get; set; }

        public List<int> ProductsId { get; set; } = null!;
    }
}

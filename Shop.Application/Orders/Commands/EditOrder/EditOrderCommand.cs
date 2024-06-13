using MediatR;

namespace Shop.Application.Orders.Commands.EditOrder
{
    public class EditOrderCommand : IRequest<OrderVm>
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public List<int> ProductsId { get; set; } = null!;
    }
}

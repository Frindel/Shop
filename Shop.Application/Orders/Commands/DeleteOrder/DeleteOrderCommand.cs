using MediatR;

namespace Shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }
}

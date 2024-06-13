using MediatR;

namespace Shop.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<OrdersListVm>
    {
        public int UserId { get; set; }
    }
}

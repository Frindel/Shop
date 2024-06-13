using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Application.Orders.Commands.EditOrder;
using Shop.Application.Orders.Queries.GetOrders;
using Shop.WebApi.Models.Orders;

namespace Shop.WebApi.Controllers
{
    [Route("/api/orders")]
    [Authorize]
    public class OrdersController : BaseController
    {
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetOrdersQuery()
            {
                UserId = CurrentUserId
            };

            var orders = await Mediator.Send(query);

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var command = new CreateOrderCommand()
            {
                UserId = CurrentUserId,
                ProductsId = request.ProductsId ?? new List<int>()
            };

            var order = await Mediator.Send(command);

            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> EditOrder(EditOrderRequest request)
        {
            var command = new EditOrderCommand()
            {
                OrderId = request.Id,
                UserId = CurrentUserId,
                ProductsId = request.ProductsId ?? new List<int>()
            };

            var order = await Mediator.Send(command);

            return Ok(order);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(DeleteOrderRequest request)
        {
            var command = new DeleteOrderCommand()
            {
                UserId = CurrentUserId,
                OrderId = request.Id
            };

            await Mediator.Send(command);

            return Ok();
        }
    }
}

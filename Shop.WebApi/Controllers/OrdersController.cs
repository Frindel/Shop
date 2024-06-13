using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Application.Orders.Commands.EditOrder;
using Shop.Application.Orders.Queries.GetOrders;
using Shop.WebApi.Models.Orders;

namespace Shop.WebApi.Controllers
{

    [Produces("application/json")]
    [Route("/api/orders")]
    [Authorize]
    public class OrdersController : BaseController
    {
        /// <summary>
        /// Get the list of user orders
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/orders
        /// </remarks>
        /// <returns>Returns list of user orders</returns>
        /// <response code="200">Success</response>
        /// <response code="400">User not found</response>
        /// <response code="401">User is unauthorized</response>
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

        /// <summary>
        /// Create the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /api/orders
        /// {
        ///     "productsId": [1, 2]
        /// }
        /// </remarks>
        /// <returns>Returns the created order with the id</returns>
        /// <response code="200">Success</response>
        /// <response code="400">User not found</response>
        /// <response code="401">User is unauthorized</response>
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

        /// <summary>
        /// Edit the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /api/orders
        /// {
        ///     "id": 1,
        ///     "productsId": [1, 2]
        /// }
        /// </remarks>
        /// <returns>Returns the edited order with the id</returns>
        /// <response code="200">Success</response>
        /// <response code="400">User, order or product not found</response>
        /// <response code="401">User is unauthorized</response>
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

        /// <summary>
        /// Delete the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/orders
        /// {
        ///     "id": 1
        /// }
        /// </remarks>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">User or order not found</response>
        /// <response code="401">User is unauthorized</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(DeleteOrderRequest request)
        {
            var command = new DeleteOrderCommand()
            {
                UserId = CurrentUserId,
                OrderId = request.Id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}

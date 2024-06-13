using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Queries.GetProducts;
using Shop.WebApi.Models.Products;

namespace Shop.WebApi.Controllers
{
    [Route("/api/products")]
    [Authorize]
    public class ProductsController : BaseController
    {
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetOrdersQuery();

            var products = await Mediator.Send(query);

            return Ok(products);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var command = new CreateProductCommand()
            {
                UserId = CurrentUserId,
                Name = request.Name,
                Price = request.Price
            };

            var addedProduct = await Mediator.Send(command);

            return Ok(addedProduct);
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequest request)
        {
            var command = new DeleteProductCommand()
            {
                UserId = CurrentUserId,
                ProductId = request.ProductId
            };

            await Mediator.Send(command);

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Queries.GetProducts;
using Shop.WebApi.Models.Products;

namespace Shop.WebApi.Controllers
{

    [Produces("application/json")]
    [Route("/api/products")]
    [Authorize]
    public class ProductsController : BaseController
    {
        /// <summary>
        /// Get the list of products
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/products
        /// </remarks>
        /// <returns>Returns list of products</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetProductsQuery();

            var products = await Mediator.Send(query);

            return Ok(products);
        }

        /// <summary>
        /// Create the product
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /api/products
        /// {
        ///     "name": "product 1",
        ///     "price": 3000
        /// }
        /// </remarks>
        /// <param name="request">CreateProductRequest object</param>
        /// <returns>Returns the created product with the id</returns>
        /// <response code="200">Success</response>
        /// <response code="400">User info not found</response>
        /// <response code="401">If the user is unauthorized</response>
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

        /// <summary>
        /// Delete the product by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /api/products
        /// {
        ///     "id": 2
        /// }
        /// </remarks>
        /// <param name="request">DeleteProductRequest object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="400">User info not found</response>
        /// <response code="401">If the user is unauthorized</response>
        /// <response code="403">User is not an admin</response>
        [HttpDelete()]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequest request)
        {
            var command = new DeleteProductCommand()
            {
                UserId = CurrentUserId,
                ProductId = request.Id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}

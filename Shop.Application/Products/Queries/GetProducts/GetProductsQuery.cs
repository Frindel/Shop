using MediatR;

namespace Shop.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<ProductsListVm>
    {
    }
}

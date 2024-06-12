using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHeandler : IRequestHandler<GetProductsQuery, ProductsListVm>
    {
        IProductsContext _products;
        IMapper _mapper;

        public GetProductsQueryHeandler(IProductsContext products, IMapper mapper)
        {
            _products = products;
            _mapper = mapper;
        }

        public async Task<ProductsListVm> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _products.Products
                .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new ProductsListVm() { Products = products };
        }
    }
}

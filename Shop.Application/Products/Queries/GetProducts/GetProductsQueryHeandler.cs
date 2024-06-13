using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Products.Queries.GetProducts
{
    public class GetOrdersQueryHeandler : IRequestHandler<GetProductsQuery, OrdersListVm>
    {
        IProductsContext _products;
        IMapper _mapper;

        public GetOrdersQueryHeandler(IProductsContext products, IMapper mapper)
        {
            _products = products;
            _mapper = mapper;
        }

        public async Task<OrdersListVm> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _products.Products
                .ProjectTo<OrderVm>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new OrdersListVm() { Products = products };
        }
    }
}

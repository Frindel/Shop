using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQueryHeandler : IRequestHandler<GetOrdersQuery, OrdersListVm>
    {
        IOrdersContext _orders;
        IUsersContext _users;
        IMapper _mapper;

        public GetOrdersQueryHeandler(IOrdersContext products, IUsersContext users, IMapper mapper)
        {
            _orders = products;
            _users = users;
            _mapper = mapper;
        }

        public async Task<OrdersListVm> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            User? currentUser = await _users
                .Users
                .FirstOrDefaultAsync(u => u.Id == request.UserId);

            if (currentUser == null)
                throw new NotFoundException("user was not found");

            var orders = await _orders.Orders.Include(o => o.Products)
                .Where(o => o.UserId == request.UserId)
                .ProjectTo<OrderVm>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new OrdersListVm() { Orders = orders };
        }
    }
}

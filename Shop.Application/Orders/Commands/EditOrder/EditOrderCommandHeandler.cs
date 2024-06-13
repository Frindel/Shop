using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Orders.Commands.EditOrder
{
    public class DeleteProductCommandHeandler : IRequestHandler<EditOrderCommand, OrderVm>
    {
        IOrdersContext _orders;
        IUsersContext _users;
        IMapper _mapper;
        IProductsContext _products;

        public DeleteProductCommandHeandler(IOrdersContext orders, IProductsContext products, IUsersContext users, IMapper mapper)
        {
            _orders = orders;
            _users = users;
            _mapper = mapper;
            _products = products;
        }
        public async Task<OrderVm> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            // получение данных текущего пользвателя
            User? currentUser = await _users
                .Users
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (currentUser == null)
                throw new NotFoundException("user was not found");

            // проверка существования заказа в БД
            Order? order = await _orders
                .Orders.Include(o=>o.Products)
                .FirstOrDefaultAsync(o => o.Id == request.OrderId && o.UserId == currentUser.Id);

            if (order == null)
                throw new NotFoundException("order was not found");

            // проверка существования товаров в БД
            var products = await _products
                .Products
                .Where(p => request.ProductsId.Contains(p.Id)).ToListAsync();

            if (products.Count != request.ProductsId.Count)
                throw new NotFoundException("products was not found");

            order.Products.Clear();
            order.Products.AddRange(products);
            await _orders.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderVm>(order);
        }
    }
}

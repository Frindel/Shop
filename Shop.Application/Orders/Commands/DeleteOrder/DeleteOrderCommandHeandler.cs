using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHeandler : IRequestHandler<DeleteOrderCommand>
    {
        IOrdersContext _orders;
        IUsersContext _users;

        public DeleteOrderCommandHeandler(IOrdersContext orders, IUsersContext users)
        {
            _orders = orders;
            _users = users;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            // получение данных текущего пользвателя
            User? currentUser = await _users
                .Users
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (currentUser == null)
                throw new NotFoundException();

            Order? order = await _orders
                .Orders
                .FirstOrDefaultAsync(p => p.Id == request.OrderId && p.UserId == currentUser.Id);

            if (order == null)
                throw new NotFoundException();

            _orders.Orders.Remove(order);
            await _orders.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

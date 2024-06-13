using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteOrderCommandHeandler : IRequestHandler<DeleteProductCommand>
    {
        IProductsContext _products;
        IUsersContext _users;

        public DeleteOrderCommandHeandler(IProductsContext products, IUsersContext users)
        {
            _products = products;
            _users = users;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // получение данных текущего пользвателя
            User? currentUser = await _users
                .Users
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (currentUser == null)
                throw new NotFoundException("user was not found");

            if (currentUser.IsAdmin == false)
                throw new ForbiddenException("user is not an admin");

            Product? product = await _products
                .Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId);

            if (product == null)
                throw new NotFoundException("products was not found");

            _products.Products.Remove(product);
            await _products.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

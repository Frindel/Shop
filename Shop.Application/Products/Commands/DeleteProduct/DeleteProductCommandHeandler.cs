using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Categories.Commands.DeleteProduct
{
    public class DeleteProductCommandHeandler : IRequestHandler<DeleteProductCommand>
    {
        IProductsContext _products;
        IUsersContext _users;

        public DeleteProductCommandHeandler(IProductsContext products, IUsersContext users)
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
                throw new NotFoundException();

            if (currentUser.IsAdmin == false)
                throw new ForbiddenException();

            Product? product = await _products
                .Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId);

            if (product == null)
                throw new NotFoundException();

            _products.Products.Remove(product);
            await _products.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

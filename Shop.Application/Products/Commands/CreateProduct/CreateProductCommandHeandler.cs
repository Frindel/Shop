using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Categories.Commands.CreateProduct
{
    public class DeleteProductCommandHeandler : IRequestHandler<CreateProductCommand, ProductVm>
    {
        IProductsContext _products;
        IUsersContext _users;
        IMapper _mapper;

        public DeleteProductCommandHeandler(IProductsContext products, IUsersContext users, IMapper mapper)
        {
            _products = products;
            _users = users;
            _mapper = mapper;
        }
        public async Task<ProductVm> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // получение данных текущего пользвателя
            User? currentUser = await _users.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (currentUser == null)
                throw new NotFoundException();

            if (currentUser.IsAdmin == false)
                throw new ForbiddenException();

            Product product = new Product()
            {
                Name = request.Name,
                Price = request.Price
            };

            await _products.Products.AddAsync(product, cancellationToken);
            await _products.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductVm>(product);
        }
    }
}

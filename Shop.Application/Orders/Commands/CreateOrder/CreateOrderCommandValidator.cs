using FluentValidation;

namespace Shop.Application.Orders.Commands.CreateOrder
{
    public class DeleteProductCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(c => c.UserId).Must(ui => ui > 0);
            RuleFor(c => c.ProductsId).NotNull().NotEmpty();
            RuleForEach(c => c.ProductsId).Must(ui => ui > 0);
        }
    }
}

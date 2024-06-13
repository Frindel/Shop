using FluentValidation;

namespace Shop.Application.Orders.Commands.EditOrder
{
    public class DeleteProductCommandValidator : AbstractValidator<EditOrderCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(c => c.UserId).Must(ui => ui > 0);
            RuleFor(c => c.OrderId).NotNull().NotEmpty();
            RuleForEach(c => c.ProductsId).Must(ui => ui > 0);
        }
    }
}

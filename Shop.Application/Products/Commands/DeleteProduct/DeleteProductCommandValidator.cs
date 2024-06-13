using FluentValidation;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(c => c.UserId).Must(ui => ui > 0);
            RuleFor(c => c.ProductId).Must(ui => ui > 0);
        }
    }
}

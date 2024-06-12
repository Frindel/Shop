using FluentValidation;

namespace Shop.Application.Categories.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(c => c.UserId).Must(ui => ui > 0);
            RuleFor(c => c.ProductId).Must(ui => ui > 0);
        }
    }
}

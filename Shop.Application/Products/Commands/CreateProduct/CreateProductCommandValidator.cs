using FluentValidation;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(c => c.UserId).Must(ui => ui > 0);
            RuleFor(c => c.Name).NotNull().NotEmpty();
        }
    }
}

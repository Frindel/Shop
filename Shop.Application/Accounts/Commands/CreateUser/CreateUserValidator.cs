using FluentValidation;

namespace Shop.Application.Accounts.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(c => c.IsAdmin).NotNull();
        }
    }
}

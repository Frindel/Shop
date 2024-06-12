using FluentValidation;

namespace Shop.Application.Accounts.Commands.UpdateAccessToken
{
    public class UpdateAccessTokenValidator : AbstractValidator<UpdateAccessTokenCommand>
    {
        public UpdateAccessTokenValidator()
        {
            RuleFor(c => c.UserId).Must(ci => ci > 0);
            RuleFor(c => c.RefreshTocken).NotNull().NotEmpty();
        }
    }
}

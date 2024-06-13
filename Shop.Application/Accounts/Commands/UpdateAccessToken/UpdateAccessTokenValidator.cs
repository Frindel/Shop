using FluentValidation;

namespace Shop.Application.Accounts.Commands.UpdateAccessToken
{
    public class UpdateAccessTokenValidator : AbstractValidator<UpdateAccessTokenCommand>
    {
        public UpdateAccessTokenValidator()
        {
            RuleFor(c => c.RefreshTocken).NotNull().NotEmpty();
        }
    }
}

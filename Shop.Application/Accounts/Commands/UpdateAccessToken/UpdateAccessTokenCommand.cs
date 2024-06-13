using MediatR;

namespace Shop.Application.Accounts.Commands.UpdateAccessToken
{
    public class UpdateAccessTokenCommand : IRequest<Tokens>
    {
        public string RefreshTocken { get; set; } = null!;
    }
}

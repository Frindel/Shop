using MediatR;

namespace Shop.Application.Accounts.Commands.UpdateAccessToken
{
    public class UpdateAccessTokenCommand : IRequest<Tokens>
    {
        public int UserId { get; set; }
        public string RefreshTocken { get; set; } = null!;
    }
}

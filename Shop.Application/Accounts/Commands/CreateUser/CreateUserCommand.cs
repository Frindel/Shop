using MediatR;

namespace Shop.Application.Accounts.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Tokens>
    {
        public bool? IsAdmin { get; set; }
    }
}

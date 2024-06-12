using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Accounts.Commands.CreateUser
{
    public class RegisterUserCummandHeandler : IRequestHandler<CreateUserCommand, Tokens>
    {
        ITokensGenerator _tokensGenerator;
        IUsersContext _users;
        public RegisterUserCummandHeandler(ITokensGenerator tokensGenerator, IUsersContext users)
        {
            _tokensGenerator = tokensGenerator;
            _users = users;
        }

        public async Task<Tokens> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            string refreshToken = _tokensGenerator.GenerateRefreshTocken();

            User createdUser = new User()
            {
                RefreshToken = refreshToken,
                IsAdmin = command.IsAdmin
            };

            await _users.Users.AddAsync(createdUser, cancellationToken);
            await _users.SaveChangesAsync(cancellationToken);

            return new Tokens()
            {
                AccessToken = _tokensGenerator.GenerateAccessTocken(createdUser.Id),
                RefreshToken = refreshToken
            };
        }
    }
}

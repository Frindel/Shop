using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Accounts.Commands.UpdateAccessToken
{
    public class UpdateAccessTokenCommandHeandler : IRequestHandler<UpdateAccessTokenCommand, Tokens>
    {
        ITokensGenerator _tokensGenerator;
        IUsersContext _users;

        public UpdateAccessTokenCommandHeandler(ITokensGenerator tokensGenerator, IUsersContext users)
        {
            _tokensGenerator = tokensGenerator;
            _users = users;
        }

        public async Task<Tokens> Handle(UpdateAccessTokenCommand request, CancellationToken cancellationToken)
        {
            var all = await _users.Users.ToListAsync();
            User? user = await _users.Users.FirstOrDefaultAsync(u => u.Id == request.UserId && u.RefreshToken == request.RefreshTocken);

            if (user == null)
                throw new NotFoundException();

            string newAccessToken = _tokensGenerator.GenerateAccessTocken(request.UserId);
            string newRefreshToken = _tokensGenerator.GenerateRefreshTocken();

            // сохранение нового refresh токена пользователя
            user.RefreshToken = newRefreshToken;
            await _users.SaveChangesAsync(cancellationToken);

            return new Tokens()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
    }
}

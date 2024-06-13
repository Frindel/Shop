using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Accounts.Commands.CreateUser;
using Shop.Application.Accounts.Commands.UpdateAccessToken;
using Shop.WebApi.Models.Accounts;

namespace Shop.WebApi.Controllers
{
    [Route("/api/accounts")]
    public class AccountsController : BaseController
    {
        [HttpGet("register")]
        public async Task<IActionResult> Register([FromQuery] RegisterRequest request)
        {
            // todo: перенести проверку в mediatoR
            if (!request.IsAdmin.HasValue)
                return BadRequest(new {error = "property \"isAdmin\" is not seted"});

            var command = new CreateUserCommand()
            {
                IsAdmin = request.IsAdmin!
            };

            var tokens = await Mediator.Send(command);

            return Ok(tokens);
        }

        [HttpPost("update-token")]
        public async Task<IActionResult> UpdateAccessToken([FromBody] UpdateAccessTokenRequest request)
        {
            var command = new UpdateAccessTokenCommand()
            {
                RefreshTocken = request.RefreshToken
            };

            var tokens = await Mediator.Send(command);

            return Ok(tokens);
        }
    }
}

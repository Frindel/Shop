using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Accounts.Commands.CreateUser;
using Shop.Application.Accounts.Commands.UpdateAccessToken;
using Shop.WebApi.Models.Accounts;

namespace Shop.WebApi.Controllers
{

    [Produces("application/json")]
    [Route("/api/accounts")]
    public class AccountsController : BaseController
    {
        /// <summary>
        /// Adding a new user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/accounts/register?isAdmin=true
        /// </remarks>
        /// <returns>Returns access and refresh tockens</returns>
        /// <response code="200">Success</response>
        [HttpGet("register")]
        public async Task<IActionResult> Register([FromQuery] RegisterRequest request)
        {
            var command = new CreateUserCommand()
            {
                IsAdmin = request.IsAdmin!
            };

            var tokens = await Mediator.Send(command);

            return Ok(tokens);
        }

        /// <summary>
        /// Reissue of access token
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /api/accounts/update-token
        /// {
        ///     "refreshToken": "xdb04oV0gHEgmGMvWXs7I4k4dMKZTwlZjNJoyUH7af4FA+dQsomacLIQcDGpJyuhNm6XqewoChBgpI2R2e9v0Q=="
        /// }
        /// </remarks>
        /// <param name="request">UpdateAccessTokenRequest object</param>
        /// <returns>Returns new access and refresh tokens</returns>
        /// <response code="200">Success</response>
        /// <response code="400">User or product was not found</response>
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

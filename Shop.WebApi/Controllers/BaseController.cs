using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Shop.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator = null!;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;

        protected int CurrentUserId { get => int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value); }

        //protected int CurrentUserId { get => 1; }
    }
}

using FluentValidation;
using System.Net;
using System.Text.Json;
using Shop.Application.Common.Exceptions;

namespace Shop.WebApi.Middleware
{
    public class ExceptionsHeandlerMiddleware
    {
        RequestDelegate _next;

        public ExceptionsHeandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exc)
            {
                await HandleException(context, exc);
            }
        }

        private Task HandleException(HttpContext context, Exception exc)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exc)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors.Select(e=>new { error = e.ErrorMessage }).ToArray());
                    break;

                case ForbiddenException:
                    code = HttpStatusCode.Forbidden;
                    result = JsonSerializer.Serialize(new { error = "You have not permission to access" });
                    break;

                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            if (result == null)
            {
                result = JsonSerializer.Serialize(new { error = exc.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}

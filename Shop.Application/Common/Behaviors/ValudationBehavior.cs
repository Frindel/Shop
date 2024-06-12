using FluentValidation;
using MediatR;

namespace Shop.Application.Common.Behaviors
{
    public class ValudationBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        IEnumerable<IValidator<TRequest>> _valudators;
        public ValudationBehavior(IEnumerable<IValidator<TRequest>> valudators)
        {
            _valudators = valudators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var a = _valudators
                .Select(v => v.Validate(request));
            var failures = _valudators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);

            return next();
        }
    }
}

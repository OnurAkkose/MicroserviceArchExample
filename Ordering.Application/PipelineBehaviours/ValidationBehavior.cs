using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.PipelineBehaviours
{
    public class ValidationBehavior<IRequest, IResponse> : IPipelineBehavior<IRequest, IResponse>
    {
        private readonly IEnumerable<IValidator<IRequest>> _validators;
        public Task<IResponse> Handle(IRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<IResponse> next)
        {
            var context = new ValidationContext<IRequest>(request);
            var failures = _validators.Select(x => x.Validate(context))
                                      .SelectMany(x => x.Errors)
                                      .Where(x => x != null)
                                      .ToList();
            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}

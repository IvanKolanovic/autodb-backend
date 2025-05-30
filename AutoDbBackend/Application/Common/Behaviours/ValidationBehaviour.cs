using System.Net;
using Application.Common.Models;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
            {
                var errors = failures.Select(f => f.ErrorMessage).ToList();

                // Check if TResponse is a Result type
                if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var resultType = typeof(TResponse).GetGenericArguments()[0];
                    var failureMethod = typeof(Result<>).MakeGenericType(resultType)
                        .GetMethod(nameof(Result<object>.Failure), new[] { typeof(string), typeof(List<string>), typeof(HttpStatusCode) });

                    var result = failureMethod?.Invoke(null, new object[] { "Validation failed", errors, HttpStatusCode.BadRequest });
                    return (TResponse)result!;
                }

                if (typeof(TResponse) == typeof(Result))
                {
                    var result = Result.Failure("Validation failed", errors, HttpStatusCode.BadRequest);
                    return (TResponse)(object)result;
                }
            }
        }

        return await next();
    }
}
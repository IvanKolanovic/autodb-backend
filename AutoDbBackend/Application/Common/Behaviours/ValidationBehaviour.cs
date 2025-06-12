using Application.Common.Results;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Count == 0) return await next();

        // Check if TResponse is a Result<T> type
        if (!typeof(TResponse).IsGenericType ||
            typeof(TResponse).GetGenericTypeDefinition() != typeof(Result<>))
            throw new ValidationException(failures);

        // Convert ValidationFailure objects to ValidationError objects
        var validationErrors = failures.Select(f =>
            ValidationError.Create(f.PropertyName, f.ErrorMessage)).ToList();

        var resultType = typeof(TResponse).GetGenericArguments()[0];
        var fromValidationErrorMethod = typeof(Result<>)
            .MakeGenericType(resultType)
            .GetMethod(nameof(Result<object>.FromValidationError));

        var result = fromValidationErrorMethod?.Invoke(null, [validationErrors]);

        return (TResponse)result!;
    }
}
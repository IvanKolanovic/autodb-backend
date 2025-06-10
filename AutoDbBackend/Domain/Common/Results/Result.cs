namespace Domain.Common.Results;


public class Result<TValue>
{
    public bool IsSuccess { get; }

    public TValue Data { get; }

    public ErrorResult Error { get; }

    public Result(TValue value)
    {
        IsSuccess = true;
        Data = value;
        Error = null!;
    }

    private Result(ErrorResult error)
    {
        IsSuccess = false;
        Data = default!;
        Error = error;
    }

    public static implicit operator Result<TValue>(TValue value) => new(value);
    public static implicit operator Result<TValue>(ErrorResult error) => new(error);

    public static Result<TValue> Failed(ErrorResult error, string detailedMessage)
    {
        var modifiedError = error with { Details = detailedMessage };
        return new Result<TValue>(modifiedError);
    }
    
    public static Result<TValue> FromValidationError(List<ValidationError> validationErrors)
    {
        var errorDetails = string.Join("\n", validationErrors.Select(e =>
            $"{e.PropertyName}: {e.ErrorMessage}"));

        var modifiedError = ApiErrors.ValidationFailed with { Details = errorDetails };
        return new Result<TValue>(modifiedError);
    }

    public static Result<TValue> Propagate(Result<dynamic> lowerResult)
    {
        return new Result<TValue>(lowerResult.Error);
    }
}
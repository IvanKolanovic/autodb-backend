using System.Net;

namespace Application.Common.Models;

public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public T? Value { get; private set; }
    public string? Message { get; private set; }
    public List<string> Errors { get; private set; } = new();
    public HttpStatusCode StatusCode { get; private set; }

    private Result(bool isSuccess, T? value, string? message, List<string>? errors, HttpStatusCode statusCode)
    {
        IsSuccess = isSuccess;
        Value = value;
        Message = message;
        Errors = errors ?? new List<string>();
        StatusCode = statusCode;
    }

    public static Result<T> Success(T value, string? message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        => new(true, value, message, null, statusCode);

    public static Result<T> Failure(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(false, default, null, new List<string> { error }, statusCode);

    public static Result<T> Failure(List<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(false, default, null, errors, statusCode);

    public static Result<T> Failure(string message, List<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(false, default, message, errors, statusCode);

    public static Result<T> NotFound(string? message = null)
        => new(false, default, message, new List<string> { message ?? "Resource not found" }, HttpStatusCode.NotFound);

    public static Result<T> Unauthorized(string? message = null)
        => new(false, default, message, new List<string> { message ?? "Unauthorized access" }, HttpStatusCode.Unauthorized);

    public static Result<T> Forbidden(string? message = null)
        => new(false, default, message, new List<string> { message ?? "Access forbidden" }, HttpStatusCode.Forbidden);
}

public class Result
{
    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }
    public List<string> Errors { get; private set; } = new();
    public HttpStatusCode StatusCode { get; private set; }

    private Result(bool isSuccess, string? message, List<string>? errors, HttpStatusCode statusCode)
    {
        IsSuccess = isSuccess;
        Message = message;
        Errors = errors ?? new List<string>();
        StatusCode = statusCode;
    }

    public static Result Success(string? message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        => new(true, message, null, statusCode);

    public static Result Failure(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(false, null, new List<string> { error }, statusCode);

    public static Result Failure(List<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(false, null, errors, statusCode);

    public static Result Failure(string message, List<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(false, message, errors, statusCode);

    public static Result NotFound(string? message = null)
        => new(false, message, new List<string> { message ?? "Resource not found" }, HttpStatusCode.NotFound);

    public static Result Unauthorized(string? message = null)
        => new(false, message, new List<string> { message ?? "Unauthorized access" }, HttpStatusCode.Unauthorized);

    public static Result Forbidden(string? message = null)
        => new(false, message, new List<string> { message ?? "Access forbidden" }, HttpStatusCode.Forbidden);
}
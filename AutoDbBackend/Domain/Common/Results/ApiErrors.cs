using System.Net;

namespace Domain.Common.Results;

public static class ApiErrors
{
    public static readonly ErrorResult ResourceNotFound = new(HttpStatusCode.NotFound, "Resource not found", "",
        "The requested resource could not be found.");

    public static readonly ErrorResult ValidationFailed = new(HttpStatusCode.BadRequest, "Validation failed",
        "One or more validation errors occurred.", "");
}
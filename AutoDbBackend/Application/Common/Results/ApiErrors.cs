using System.Net;

namespace Application.Common.Results;

public static class ApiErrors
{
    public static readonly ErrorResult InternalServerError = new(HttpStatusCode.InternalServerError, "Internal server error", "",
        "Internal server error");

    public static readonly ErrorResult ValidationFailed = new(HttpStatusCode.BadRequest, "Validation failed",
        "One or more validation errors occurred.", "");

    public static readonly ErrorResult NotFound = new(HttpStatusCode.NotFound, "Not found", "",
        "The requested item could not be found.");
    
}
namespace Domain.Common.Results;

using System.Net;

public sealed record ErrorResult(
    HttpStatusCode StatusCode,
    string Title,
    string Message,
    string Details);
using System.Net;

namespace Application.Common.Results;

public sealed record ErrorResult(
    HttpStatusCode StatusCode,
    string Title,
    string Message,
    string Details);
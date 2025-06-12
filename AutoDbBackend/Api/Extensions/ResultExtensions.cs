using Application.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace AutoDbBackend.Extensions;

public static class ResultExtensions
{
    private static readonly string[] value = new[] { "item1", "item2" };

    public static ActionResult<T> ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new OkObjectResult(result);
        }

        return new JsonResult(result)
        {
            StatusCode = (int)result.Error.StatusCode
        };
    }
}
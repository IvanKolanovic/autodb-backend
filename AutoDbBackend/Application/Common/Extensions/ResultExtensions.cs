using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Common.Extensions;

public static class ResultExtensions
{
    public static ActionResult<T> ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            var response = new
            {
                success = true,
                message = result.Message,
                data = result.Value
            };

            return new ObjectResult(response)
            {
                StatusCode = (int)result.StatusCode
            };
        }

        var errorResponse = new
        {
            success = false,
            message = result.Message,
            errors = result.Errors
        };

        return new ObjectResult(errorResponse)
        {
            StatusCode = (int)result.StatusCode
        };
    }

    public static ActionResult ToActionResult(this Result result)
    {
        if (result.IsSuccess)
        {
            var response = new
            {
                success = true,
                message = result.Message
            };

            return new ObjectResult(response)
            {
                StatusCode = (int)result.StatusCode
            };
        }

        var errorResponse = new
        {
            success = false,
            message = result.Message,
            errors = result.Errors
        };

        return new ObjectResult(errorResponse)
        {
            StatusCode = (int)result.StatusCode
        };
    }
}
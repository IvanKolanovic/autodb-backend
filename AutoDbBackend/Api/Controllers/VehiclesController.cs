using Application.Features.Vehicles.Queries.InitialCarSearch;
using Application.Features.Vehicles.Queries.YmmtCarSearch;
using Application.Repositories.Nhtsa.Models;
using AutoDbBackend.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoDbBackend.Controllers;

[ApiController]
[Route("api/vehicles")]
public class VehiclesController(IMediator mediator) : ControllerBase
{
    [HttpGet("initial-search")]
    public async Task<ActionResult<BySearchDto>> GetInitialCarSearch([FromQuery] string query,
        [FromQuery] int offset = 0, [FromQuery] int max = 20)
    {
        var result = await mediator.Send(new GetInitialCarSearchQuery
        {
            Query = query,
            Offset = offset,
            Max = max
        });
        return result.ToActionResult();
    }

    [HttpGet("ymmt")]
    public async Task<ActionResult<ByYmmtDto>> GetYmmtCarDetails([FromQuery] int modelYear, [FromQuery] string make,
        [FromQuery] string model,
        [FromQuery] string trim, [FromQuery] string series)
    {
        var result = await mediator.Send(new GetYmmtCarDetailsQuery
        {
            Make = make,
            Model = model,
            Trim = trim,
            Year = modelYear,
            Series = series
        });
        return result.ToActionResult();
    }
}
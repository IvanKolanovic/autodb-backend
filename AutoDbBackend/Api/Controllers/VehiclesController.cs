using Application.Features.Vehicles.Queries;
using Application.Features.Vehicles.Queries.InitialCarSearch;
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
    public async Task<ActionResult<BySearchDto>> GetInitialCarSearch([FromQuery] string query, [FromQuery] int offset = 0, [FromQuery] int max = 20)
    {
        var result = await mediator.Send(new GetInitialCarSearchQuery
        {
            Query = query,
            Offset = offset,
            Max = max
        });
        return result.ToActionResult();
    }
}
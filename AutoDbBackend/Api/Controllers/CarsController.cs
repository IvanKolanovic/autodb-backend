using Application.Features.Cars.Commands;
using AutoDbBackend.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoDbBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Creates a new car with standard error response
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CarDto>> CreateCar(CreateCarCommand command)
    {
        var result = await mediator.Send(command);
        return result.ToActionResult();
    }

    /// <summary>
    /// Creates a new car with structured validation error response
    /// </summary>
    [HttpPost("structured")]
    public async Task<ActionResult<CarDto>> CreateCarStructured(CreateCarCommand command)
    {
        var result = await mediator.Send(command);
        return result.ToActionResult();
    }
}
using Application.Common.Extensions;
using Application.Common.Models;
using Application.Features.Cars.Commands;
using Application.Features.Cars.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoDbBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetAllCars()
    {
        var query = new GetAllCarsQuery();
        var result = await _mediator.Send(query);

        return result.ToActionResult();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> GetCarById(int id)
    {
        var query = new GetCarByIdQuery(id);
        var result = await _mediator.Send(query);

        return result.ToActionResult();
    }

    [HttpPost]
    public async Task<ActionResult<Car>> CreateCar(CreateCarCommand command)
    {
        var result = await _mediator.Send(command);

        return result.ToActionResult();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Car>> UpdateCar(int id, [FromBody] UpdateCarRequest request)
    {
        var command = new UpdateCarCommand(id, request.Make, request.Model, request.Year);
        var result = await _mediator.Send(command);

        return result.ToActionResult();
    }
}

public record UpdateCarRequest(string Make, string Model, int Year);
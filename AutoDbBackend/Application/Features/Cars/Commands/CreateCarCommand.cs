using System.Net;
using Application.Common.Models;
using MediatR;

namespace Application.Features.Cars.Commands;

public record CreateCarCommand(string Make, string Model, int Year) : IRequest<Result<Car>>;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<Car>>
{
    public Task<Result<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        // Validation is handled by FluentValidation in the pipeline
        // Simulate creating a car
        var car = new Car
        {
            Id = Random.Shared.Next(1, 1000),
            Make = request.Make,
            Model = request.Model,
            Year = request.Year
        };

        return Task.FromResult(Result<Car>.Success(
            car,
            "Car created successfully",
            HttpStatusCode.Created));
    }
}
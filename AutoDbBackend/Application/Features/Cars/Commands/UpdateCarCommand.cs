using System.Net;
using Application.Common.Models;
using MediatR;

namespace Application.Features.Cars.Commands;

public record UpdateCarCommand(int Id, string Make, string Model, int Year) : IRequest<Result<Car>>;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Result<Car>>
{
    // Simulate some data
    private static readonly List<Car> Cars = new()
    {
        new Car { Id = 1, Make = "Toyota", Model = "Camry", Year = 2023 },
        new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2022 },
        new Car { Id = 3, Make = "Ford", Model = "Mustang", Year = 2024 }
    };

    public Task<Result<Car>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        // Validation is handled by FluentValidation in the pipeline
        var existingCar = Cars.FirstOrDefault(c => c.Id == request.Id);

        if (existingCar == null)
        {
            return Task.FromResult(Result<Car>.NotFound(
                $"Car with ID {request.Id} was not found"));
        }

        // Simulate updating the car
        existingCar.Make = request.Make;
        existingCar.Model = request.Model;
        existingCar.Year = request.Year;

        return Task.FromResult(Result<Car>.Success(
            existingCar,
            "Car updated successfully"));
    }
}
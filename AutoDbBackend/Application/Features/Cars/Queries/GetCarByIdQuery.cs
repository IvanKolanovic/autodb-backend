using System.Net;
using Application.Common.Models;
using MediatR;

namespace Application.Features.Cars.Queries;

public record GetCarByIdQuery(int Id) : IRequest<Result<Car>>;

public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Result<Car>>
{
    // Simulate some data
    private static readonly List<Car> Cars = new()
    {
        new Car { Id = 1, Make = "Toyota", Model = "Camry", Year = 2023 },
        new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2022 },
        new Car { Id = 3, Make = "Ford", Model = "Mustang", Year = 2024 }
    };

    public Task<Result<Car>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        // Validation is handled by FluentValidation in the pipeline
        var car = Cars.FirstOrDefault(c => c.Id == request.Id);

        if (car == null)
        {
            return Task.FromResult(Result<Car>.NotFound(
                $"Car with ID {request.Id} was not found"));
        }

        return Task.FromResult(Result<Car>.Success(
            car,
            "Car retrieved successfully"));
    }
}
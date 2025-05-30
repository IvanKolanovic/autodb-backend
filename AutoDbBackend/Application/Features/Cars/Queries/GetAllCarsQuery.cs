using System.Net;
using Application.Common.Models;
using MediatR;

namespace Application.Features.Cars.Queries;

public record GetAllCarsQuery : IRequest<Result<List<Car>>>;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, Result<List<Car>>>
{
    // Simulate some data
    private static readonly List<Car> Cars = new()
    {
        new Car { Id = 1, Make = "Toyota", Model = "Camry", Year = 2023 },
        new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2022 },
        new Car { Id = 3, Make = "Ford", Model = "Mustang", Year = 2024 }
    };

    public Task<Result<List<Car>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        // Simulate different scenarios
        if (!Cars.Any())
        {
            return Task.FromResult(Result<List<Car>>.Success(
                new List<Car>(),
                "No cars found in the system",
                HttpStatusCode.OK));
        }

        return Task.FromResult(Result<List<Car>>.Success(
            Cars,
            $"Successfully retrieved {Cars.Count} cars"));
    }
}
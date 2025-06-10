using Domain.Common.Results;
using MediatR;

namespace Application.Features.Cars.Commands;

public record CreateCarCommand(string Make, string Model, int Year) : IRequest<Result<CarDto>>;

public record CarDto(int Id, string Make, string Model, int Year);

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<CarDto>>
{
    public Task<Result<CarDto>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        // Validation is handled by the ValidationBehaviour in the pipeline
        // If we reach here, validation has passed

        // Simulate creating a car
        var car = new CarDto(
            Id: Random.Shared.Next(1, 1000),
            Make: request.Make,
            Model: request.Model,
            Year: request.Year
        );

        return Task.FromResult<Result<CarDto>>(car);
    }
}

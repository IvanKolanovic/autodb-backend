using FluentValidation;

namespace Application.Features.Cars.Queries;

public class GetCarByIdQueryValidator : AbstractValidator<GetCarByIdQuery>
{
    public GetCarByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Car ID must be greater than 0");
    }
}
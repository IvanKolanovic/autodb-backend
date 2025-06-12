using FluentValidation;

namespace Application.Features.Vehicles.Queries.InitialCarSearch;

public class GetInitialCarSearchQueryValidator : AbstractValidator<GetInitialCarSearchQuery>
{
    public GetInitialCarSearchQueryValidator()
    {
        RuleFor(x => x.Query)
            .NotEmpty()
            .WithMessage("Query parameter is required")
            .MinimumLength(2)
            .WithMessage("Query must be at least 2 characters long")
            .MaximumLength(100)
            .WithMessage("Query must not exceed 100 characters");

        RuleFor(x => x.Offset)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Offset must be greater than or equal to 0");

        RuleFor(x => x.Max)
            .GreaterThan(0)
            .WithMessage("Max must be greater than 0")
            .LessThanOrEqualTo(100)
            .WithMessage("Max must not exceed 100");
    }
}
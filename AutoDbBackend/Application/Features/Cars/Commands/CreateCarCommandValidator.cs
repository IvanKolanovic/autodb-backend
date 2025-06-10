using FluentValidation;

namespace Application.Features.Cars.Commands;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(x => x.Make)
            .NotEmpty()
            .WithMessage("Make is required")
            .MaximumLength(50)
            .WithMessage("Make must not exceed 50 characters");

        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage("Model is required")
            .MaximumLength(50)
            .WithMessage("Model must not exceed 50 characters");

        RuleFor(x => x.Year)
            .GreaterThan(1900)
            .WithMessage("Year must be greater than 1900")
            .LessThanOrEqualTo(DateTime.Now.Year + 1)
            .WithMessage($"Year must not be greater than {DateTime.Now.Year + 1}");
    }
}
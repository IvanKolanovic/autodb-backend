using FluentValidation;

namespace Application.Features.Cars.Commands;

public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    private static readonly string[] AllowedMakes = { "Toyota", "Honda", "Ford", "BMW", "Mercedes", "Audi", "Volkswagen" };

    public UpdateCarCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Car ID must be greater than 0");

        RuleFor(x => x.Make)
            .NotEmpty()
            .WithMessage("Make is required")
            .MaximumLength(50)
            .WithMessage("Make must not exceed 50 characters")
            .Must(make => AllowedMakes.Contains(make, StringComparer.OrdinalIgnoreCase))
            .WithMessage($"Make must be one of: {string.Join(", ", AllowedMakes)}");

        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage("Model is required")
            .MaximumLength(50)
            .WithMessage("Model must not exceed 50 characters")
            .Matches("^[a-zA-Z0-9 -]+$")
            .WithMessage("Model can only contain letters, numbers, spaces, and hyphens");

        RuleFor(x => x.Year)
            .InclusiveBetween(1900, DateTime.Now.Year + 1)
            .WithMessage($"Year must be between 1900 and {DateTime.Now.Year + 1}");

        // Custom validation rule
        RuleFor(x => x)
            .Must(BeValidCarCombination)
            .WithMessage("This make and model combination is not valid")
            .WithName("Car");
    }

    private static bool BeValidCarCombination(UpdateCarCommand command)
    {
        // Example: Toyota models must start with certain letters
        if (command.Make.Equals("Toyota", StringComparison.OrdinalIgnoreCase))
        {
            var validToyotaModels = new[] { "Camry", "Corolla", "Prius", "RAV4", "Highlander" };
            return validToyotaModels.Any(model =>
                command.Model.StartsWith(model, StringComparison.OrdinalIgnoreCase));
        }

        return true; // Allow other combinations
    }
}
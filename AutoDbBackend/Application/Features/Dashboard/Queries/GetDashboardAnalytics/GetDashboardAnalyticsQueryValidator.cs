using FluentValidation;

namespace Application.Features.Dashboard.Queries.GetDashboardAnalytics;

public class GetDashboardAnalyticsQueryValidator : AbstractValidator<GetDashboardAnalyticsQuery>
{
    public GetDashboardAnalyticsQueryValidator()
    {
        RuleFor(x => x.RecentRecallsCount)
            .GreaterThan(0).WithMessage("Recent recalls count must be greater than 0")
            .LessThanOrEqualTo(100).WithMessage("Recent recalls count must be less than or equal to 100");

        RuleFor(x => x.TopManufacturersCount)
            .GreaterThan(0).WithMessage("Top manufacturers count must be greater than 0")
            .LessThanOrEqualTo(20).WithMessage("Top manufacturers count must be less than or equal to 20");

        RuleFor(x => x.MostRecalledVehiclesCount)
            .GreaterThan(0).WithMessage("Most recalled vehicles count must be greater than 0")
            .LessThanOrEqualTo(20).WithMessage("Most recalled vehicles count must be less than or equal to 20");

        RuleFor(x => x.StartYear)
            .GreaterThanOrEqualTo(0).WithMessage("Start year must be greater than or equal to 0")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Start year must be less than or equal to {DateTime.Now.Year}");

        RuleFor(x => x.EndYear)
            .GreaterThanOrEqualTo(0).WithMessage("End year must be greater than or equal to 0")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"End year must be less than or equal to {DateTime.Now.Year}")
            .GreaterThanOrEqualTo(x => x.StartYear).When(x => x.StartYear > 0 && x.EndYear > 0)
            .WithMessage("End year must be greater than or equal to start year");
    }
}
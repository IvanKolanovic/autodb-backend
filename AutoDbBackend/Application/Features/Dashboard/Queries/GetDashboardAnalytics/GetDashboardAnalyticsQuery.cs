using Application.Common.Results;
using Application.Models;
using Application.Repositories.Dashboard;
using MediatR;

namespace Application.Features.Dashboard.Queries.GetDashboardAnalytics;

public class GetDashboardAnalyticsQuery : IRequest<Result<DashboardAnalyticsDto>>
{
    public int RecentRecallsCount { get; init; } = 10;
    public int TopManufacturersCount { get; init; } = 5;
    public int MostRecalledVehiclesCount { get; init; } = 5;
}

public class GetDashboardAnalyticsQueryHandler : IRequestHandler<GetDashboardAnalyticsQuery, Result<DashboardAnalyticsDto>>
{
    private readonly IDashboardRepository _dashboardRepository;

    public GetDashboardAnalyticsQueryHandler(IDashboardRepository dashboardRepository)
    {
        _dashboardRepository = dashboardRepository;
    }

    public async Task<Result<DashboardAnalyticsDto>> Handle(GetDashboardAnalyticsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Get recent recalls
            var recentRecalls = await _dashboardRepository.GetRecentRecalls(request.RecentRecallsCount);

            // Get recalls by manufacturer
            var recallsByManufacturer = await _dashboardRepository.GetRecallsByManufacturer(request.TopManufacturersCount);

            // Get most recalled vehicles
            var mostRecalledVehicles = await _dashboardRepository.GetMostRecalledVehicles(request.MostRecalledVehiclesCount);

            // Create the dashboard analytics DTO
            var dashboardAnalytics = new DashboardAnalyticsDto
            {
                Meta = new MetaDto
                {
                    Status = 200,
                    Messages = new List<string>(),
                    Pagination = new PaginationDto
                    {
                        Count = recentRecalls.Count + recallsByManufacturer.Count + mostRecalledVehicles.Count,
                        Total = recentRecalls.Count + recallsByManufacturer.Count + mostRecalledVehicles.Count
                    }
                },
                RecentRecalls = recentRecalls,
                RecallsByManufacturer = recallsByManufacturer,
                MostRecalledVehicles = mostRecalledVehicles
            };

            return dashboardAnalytics;
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine(ex);

            // Return an error result
            return ApiErrors.InternalServerError;
        }
    }
}
using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Models;
using Application.Repositories.Dashboard;
using MediatR;
using System.Text.Json;

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
    private readonly ICacheService _cacheService;
    private const string CacheKeyPrefix = "dashboard_analytics";
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromHours(1);

    public GetDashboardAnalyticsQueryHandler(
        IDashboardRepository dashboardRepository,
        ICacheService cacheService)
    {
        _dashboardRepository = dashboardRepository;
        _cacheService = cacheService;
    }

    public async Task<Result<DashboardAnalyticsDto>> Handle(GetDashboardAnalyticsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Generate a cache key based on the request parameters
            var cacheKey = $"{CacheKeyPrefix}_{request.RecentRecallsCount}_{request.TopManufacturersCount}_{request.MostRecalledVehiclesCount}";

            // Try to get from cache first
            var cachedResult = await _cacheService.GetAsync<DashboardAnalyticsDto>(cacheKey);
            if (cachedResult != null)
            {
                Console.WriteLine("Returning dashboard analytics from cache");
                return cachedResult;
            }

            Console.WriteLine("Cache miss for dashboard analytics, fetching from repository");

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

            // Cache the result
            await _cacheService.SetAsync(cacheKey, dashboardAnalytics, _cacheExpiration);
            Console.WriteLine($"Dashboard analytics cached with key: {cacheKey}");

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
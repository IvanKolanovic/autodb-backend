using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Models;
using Application.Repositories.Dashboard;
using Application.Repositories.Safety;
using MediatR;
using System.Text.Json;

namespace Application.Features.Dashboard.Queries.GetDashboardAnalytics;

public class GetDashboardAnalyticsQuery : IRequest<Result<DashboardAnalyticsDto>>
{
    public int RecentRecallsCount { get; init; } = 10;
    public int TopManufacturersCount { get; init; } = 5;
    public int MostRecalledVehiclesCount { get; init; } = 5;
    public int StartYear { get; init; } = 0;
    public int EndYear { get; init; } = 0;
}

public class GetDashboardAnalyticsQueryHandler(
    IDashboardRepository dashboardRepository,
    ISafetyRepository safetyRepository,
    ICacheService cacheService)
    : IRequestHandler<GetDashboardAnalyticsQuery, Result<DashboardAnalyticsDto>>
{
    private const string CacheKeyPrefix = "dashboard_analytics";
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromHours(1);

    public async Task<Result<DashboardAnalyticsDto>> Handle(GetDashboardAnalyticsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Generate a cache key based on the request parameters
            var cacheKey = $"{CacheKeyPrefix}_{request.RecentRecallsCount}_{request.TopManufacturersCount}_{request.MostRecalledVehiclesCount}_{request.StartYear}_{request.EndYear}";

            // Try to get from cache first
            var cachedResult = await cacheService.GetAsync<DashboardAnalyticsDto>(cacheKey);
            if (cachedResult != null)
            {
                Console.WriteLine("Returning dashboard analytics from cache");
                return cachedResult;
            }

            Console.WriteLine("Cache miss for dashboard analytics, fetching from repository");

            // Get recent recalls
            var recentRecalls = await dashboardRepository.GetRecentRecalls(request.RecentRecallsCount);

            // Get recalls by manufacturer
            var recallsByManufacturer = await dashboardRepository.GetRecallsByManufacturer(request.TopManufacturersCount);

            // Get most recalled vehicles
            var mostRecalledVehicles = await dashboardRepository.GetMostRecalledVehicles(request.MostRecalledVehiclesCount);

            // Get recalls by year
            var recallsByYear = await dashboardRepository.GetRecallsByYear(request.StartYear, request.EndYear);

            // Get crash test performance data
            var crashTestPerformance = await safetyRepository.GetCrashTestPerformanceByManufacturer();

            // Get rollover resistance data
            var rolloverResistanceData = await safetyRepository.GetRolloverResistanceData();

            // Create the dashboard analytics DTO
            var dashboardAnalytics = new DashboardAnalyticsDto
            {
                RecentRecalls = recentRecalls,
                RecallsByManufacturer = recallsByManufacturer,
                MostRecalledVehicles = mostRecalledVehicles,
                RecallsByYear = recallsByYear,
                CrashTestPerformance = crashTestPerformance,
                RolloverResistanceData = rolloverResistanceData
            };

            // Cache the result
            await cacheService.SetAsync(cacheKey, dashboardAnalytics, _cacheExpiration);
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
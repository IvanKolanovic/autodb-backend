using Application.Features.Dashboard.Queries.GetDashboardAnalytics;
using Application.Models;
using AutoDbBackend.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoDbBackend.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController(IMediator mediator) : ControllerBase
{
    [HttpGet("analytics")]
    public async Task<ActionResult<DashboardAnalyticsDto>> GetDashboardAnalytics(
        [FromQuery] int recentRecallsCount = 10,
        [FromQuery] int topManufacturersCount = 5,
        [FromQuery] int mostRecalledVehiclesCount = 5)
    {
        var result = await mediator.Send(new GetDashboardAnalyticsQuery
        {
            RecentRecallsCount = recentRecallsCount,
            TopManufacturersCount = topManufacturersCount,
            MostRecalledVehiclesCount = mostRecalledVehiclesCount,
            StartYear = 2015,
            EndYear = 2025
        });

        return result.ToActionResult();
    }
}
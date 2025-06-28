using Application.Features.Dashboard.Queries.GetDashboardAnalytics;
using Application.Models;
using AutoDbBackend.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoDbBackend.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("analytics")]
    public async Task<ActionResult<DashboardAnalyticsDto>> GetDashboardAnalytics(
        [FromQuery] int recentRecallsCount = 10,
        [FromQuery] int topManufacturersCount = 5,
        [FromQuery] int mostRecalledVehiclesCount = 5)
    {
        var result = await _mediator.Send(new GetDashboardAnalyticsQuery
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
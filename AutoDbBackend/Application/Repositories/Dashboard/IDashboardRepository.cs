using Application.Models;

namespace Application.Repositories.Dashboard;

public interface IDashboardRepository
{
    Task<List<RecentRecallDto>> GetRecentRecalls(int count = 10);
    Task<List<ManufacturerRecallCountDto>> GetRecallsByManufacturer(int maxCount = 5);
    Task<List<MostRecalledVehicleDto>> GetMostRecalledVehicles(int maxCount = 5);
    Task<List<RecallsByYearDto>> GetRecallsByYear(int startYear = 0, int endYear = 0);
}
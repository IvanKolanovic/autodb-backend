using Application.Models;

namespace Application.Repositories.Safety;

public interface ISafetyRepository
{
    Task<List<SafetyDataDto>> GetAllSafetyData();
    Task<List<CrashTestPerformanceDto>> GetCrashTestPerformanceByManufacturer();
    Task<List<RolloverResistanceDto>> GetRolloverResistanceData();
}
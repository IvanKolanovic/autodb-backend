using Application.Repositories.Nhtsa.Models;
using Refit;

namespace Application.Repositories.Nhtsa;

public interface INhtsaRepository
{
    [Get("/vehicles/bySearch")]
    Task<BySearchDto> BySearchQuery([Query] BySearchQueryParam queryParam);
    
    [Get("/vehicles/byYmmt")]
    Task<ByYmmtDto> ByYmmt([Query] ByYmmtQueryParam queryParam);

    [Get("/vehicles/{vehicleId}/details?data=complaints,recalls,investigations,manufacturercommunications&productDetail=minimal")]
    Task<ByYmmtDto> ByYmmtDetails(int vehicleId);

}
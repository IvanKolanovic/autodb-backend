using Application.Repositories.Nhtsa.Models;
using Refit;

namespace Application.Repositories.Nhtsa;

public interface INhtsaRepository
{
    [Get("/vehicles/bySearch")]
    Task<BySearchDto> BySearchQuery([Query] BySearchQueryParam queryParam);
}
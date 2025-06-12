using Application.Common.Results;
using Application.Repositories.Nhtsa;
using Application.Repositories.Nhtsa.Models;
using MediatR;

namespace Application.Features.Vehicles.Queries.InitialCarSearch;

public class GetInitialCarSearchQuery : IRequest<Result<BySearchDto>>
{
    public string Query { get; init; } = "";
    public int Offset { get; init; }
    public int Max { get; init; } = 100;
}

internal class GetInitialCarSearchQueryHandler(INhtsaRepository nhtsaRepository)
    : IRequestHandler<GetInitialCarSearchQuery, Result<BySearchDto>>
{
    public async Task<Result<BySearchDto>> Handle(GetInitialCarSearchQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParam = new BySearchQueryParam
            {
                offset = request.Offset,
                max = request.Max,
                data = "none",
                productDetail = "all",
                query = request.Query ?? string.Empty
            };

            var result = await nhtsaRepository.BySearchQuery(queryParam);
            return result;
        }
        catch (Exception e)
        {
//          return Result<BySearchDto>.Failed(ApiErrors.InternalServerError);\
            Console.WriteLine(e);
            return null;
        }
    }
}
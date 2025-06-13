using Application.Common.Results;
using Application.Repositories.Nhtsa;
using Application.Repositories.Nhtsa.Models;
using MediatR;

namespace Application.Features.Vehicles.Queries.YmmtCarSearch;

public class GetYmmtCarDetailsQuery : IRequest<Result<ByYmmtDto>>
{
    public int Year { get; set; }
    public required string Make { get; set; }
    public required string Model { get; set; }
    public required string Trim { get; set; }
    public required string Series { get; set; }
}

public class GetYmmtCarDetailsQueryHandler(INhtsaRepository nhtsaRepository)
    : IRequestHandler<GetYmmtCarDetailsQuery, Result<ByYmmtDto>>
{
    public async Task<Result<ByYmmtDto>> Handle(GetYmmtCarDetailsQuery request, CancellationToken cancellationToken)
    {
        var param = new ByYmmtQueryParam
        {
            make = request.Make,
            model = request.Model,
            trim = request.Trim,
            modelYear = request.Year,
            series = request.Series
        };

        var ymmt = await nhtsaRepository.ByYmmt(param);
        if (ymmt.Results.Count == 0)
        {
            //return Result<ByYmmtDto>.Failed()
        }
        
        
        
        var ymmtDetails = await nhtsaRepository.ByYmmtDetails(ymmt.Results[0].VehicleId);

        ymmt.Results[0].SafetyIssues = ymmtDetails.Results[0].SafetyIssues;

        return ymmt;
    }
}
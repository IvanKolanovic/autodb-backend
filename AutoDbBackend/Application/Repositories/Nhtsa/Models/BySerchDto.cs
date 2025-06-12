using System.Text.Json.Serialization;
using Application.Models;

namespace Application.Repositories.Nhtsa.Models;

public class BySearchDto
{
    [JsonPropertyName("meta")]
    public MetaDto Meta { get; set; } = new();

    [JsonPropertyName("results")]
    public List<VehicleResultDto> Results { get; set; } = [];
}

public class VehicleResultDto
{
    [JsonPropertyName("vehicleId")]
    public int VehicleId { get; set; }

    [JsonPropertyName("parkIt")]
    public bool ParkIt { get; set; }

    [JsonPropertyName("parkOutSide")]
    public bool ParkOutSide { get; set; }

    [JsonPropertyName("overTheAirUpdate")]
    public bool OverTheAirUpdate { get; set; }

    [JsonPropertyName("artemisId")]
    public int ArtemisId { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("ncapId")]
    public int? NcapId { get; set; }

    [JsonPropertyName("modelYear")]
    public int ModelYear { get; set; }

    [JsonPropertyName("make")]
    public string Make { get; set; } = string.Empty;

    [JsonPropertyName("vehicleModel")]
    public string VehicleModel { get; set; } = string.Empty;

    [JsonPropertyName("trim")]
    public string? Trim { get; set; }

    [JsonPropertyName("series")]
    public string? Series { get; set; }

    [JsonPropertyName("class")]
    public string? Class { get; set; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; } = string.Empty;

    [JsonPropertyName("vehiclePicture")]
    public string? VehiclePicture { get; set; }

    [JsonPropertyName("ncapRated")]
    public bool NcapRated { get; set; }

    [JsonPropertyName("complaintsCount")]
    public int ComplaintsCount { get; set; }

    [JsonPropertyName("recallsCount")]
    public int RecallsCount { get; set; }

    [JsonPropertyName("investigationsCount")]
    public int InvestigationsCount { get; set; }

    [JsonPropertyName("manufacturerCommunicationsCount")]
    public int ManufacturerCommunicationsCount { get; set; }
}
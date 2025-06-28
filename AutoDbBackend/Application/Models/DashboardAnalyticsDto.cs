using System.Text.Json.Serialization;

namespace Application.Models;

public class DashboardAnalyticsDto
{
    [JsonPropertyName("meta")]
    public MetaDto Meta { get; set; } = new();

    [JsonPropertyName("recentRecalls")]
    public List<RecentRecallDto> RecentRecalls { get; set; } = [];

    [JsonPropertyName("recallsByManufacturer")]
    public List<ManufacturerRecallCountDto> RecallsByManufacturer { get; set; } = [];

    [JsonPropertyName("mostRecalledVehicles")]
    public List<MostRecalledVehicleDto> MostRecalledVehicles { get; set; } = [];
}

public class ManufacturerRecallCountDto
{
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; } = string.Empty;

    [JsonPropertyName("recallCount")]
    public int RecallCount { get; set; }
}

public class MostRecalledVehicleDto
{
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; } = string.Empty;

    [JsonPropertyName("recallCount")]
    public int RecallCount { get; set; }

    [JsonPropertyName("issueDescription")]
    public string IssueDescription { get; set; } = string.Empty;
}

public class RecentRecallDto
{
    [JsonPropertyName("reportReceivedDate")]
    public string ReportReceivedDate { get; set; } = string.Empty;

    [JsonPropertyName("nhtsaId")]
    public string NhtsaId { get; set; } = string.Empty;

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; } = string.Empty;

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = string.Empty;

    [JsonPropertyName("component")]
    public string Component { get; set; } = string.Empty;

    [JsonPropertyName("campaignNumber")]
    public string CampaignNumber { get; set; } = string.Empty;

    [JsonPropertyName("recallType")]
    public string RecallType { get; set; } = string.Empty;

    [JsonPropertyName("potentiallyAffected")]
    public string PotentiallyAffected { get; set; } = string.Empty;

    [JsonPropertyName("recallDescription")]
    public string RecallDescription { get; set; } = string.Empty;

    [JsonPropertyName("consequenceSummary")]
    public string ConsequenceSummary { get; set; } = string.Empty;

    [JsonPropertyName("correctiveAction")]
    public string CorrectiveAction { get; set; } = string.Empty;

    [JsonPropertyName("parkOutsideAdvisory")]
    public string ParkOutsideAdvisory { get; set; } = string.Empty;

    [JsonPropertyName("doNotDriveAdvisory")]
    public string DoNotDriveAdvisory { get; set; } = string.Empty;

    [JsonPropertyName("completionRate")]
    public string CompletionRate { get; set; } = string.Empty;
}
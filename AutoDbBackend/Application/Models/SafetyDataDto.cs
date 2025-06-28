using System.Text.Json.Serialization;

namespace Application.Models;

public class SafetyDataDto
{
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; } = string.Empty;

    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("bodyType")]
    public string BodyType { get; set; } = string.Empty;

    [JsonPropertyName("vehicleType")]
    public string VehicleType { get; set; } = string.Empty;

    [JsonPropertyName("driveType")]
    public string DriveType { get; set; } = string.Empty;

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("overallRating")]
    public int OverallRating { get; set; }

    [JsonPropertyName("frontCrashRating")]
    public int FrontCrashRating { get; set; }

    [JsonPropertyName("sideCrashRating")]
    public int SideCrashRating { get; set; }

    [JsonPropertyName("rolloverRating")]
    public int RolloverRating { get; set; }

    [JsonPropertyName("rolloverResistance")]
    public double RolloverResistance { get; set; }

    [JsonPropertyName("hasTipped")]
    public bool HasTipped { get; set; }
}

public class CrashTestPerformanceDto
{
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; } = string.Empty;

    [JsonPropertyName("totalTests")]
    public int TotalTests { get; set; }

    [JsonPropertyName("passedTests")]
    public int PassedTests { get; set; }

    [JsonPropertyName("failedTests")]
    public int FailedTests { get; set; }

    [JsonPropertyName("passRate")]
    public double PassRate { get; set; }
}

public class RolloverResistanceDto
{
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; } = string.Empty;

    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("rolloverResistance")]
    public double RolloverResistance { get; set; }
}
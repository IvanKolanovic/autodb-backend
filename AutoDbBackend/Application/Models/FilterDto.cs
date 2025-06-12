using System.Text.Json.Serialization;

namespace Application.Models;

public class FilterDto
{
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("count")]
    public int Count { get; set; }
}
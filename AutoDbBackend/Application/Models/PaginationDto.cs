using System.Text.Json.Serialization;

namespace Application.Models;

public class PaginationDto
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("max")]
    public int Max { get; set; }

    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    [JsonPropertyName("sort")]
    public string Sort { get; set; } = string.Empty;

    [JsonPropertyName("order")]
    public string? Order { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("currentUrl")]
    public string CurrentUrl { get; set; } = string.Empty;

    [JsonPropertyName("nextUrl")]
    public string? NextUrl { get; set; }

    [JsonPropertyName("previousUrl")]
    public string? PreviousUrl { get; set; }
}

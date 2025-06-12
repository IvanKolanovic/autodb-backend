using System.Text.Json.Serialization;
using Application.Repositories.Nhtsa.Models;

namespace Application.Models;

public class MetaDto
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("messages")]
    public List<string> Messages { get; set; } = [];

    [JsonPropertyName("pagination")]
    public PaginationDto Pagination { get; set; } = new();

    [JsonPropertyName("filters")]
    public List<FilterDto> Filters { get; set; } = [];

    [JsonPropertyName("decoder")]
    public List<object> Decoder { get; set; } = [];
}
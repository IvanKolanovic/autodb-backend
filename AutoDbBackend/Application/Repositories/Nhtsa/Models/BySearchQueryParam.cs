
namespace Application.Repositories.Nhtsa.Models;

public class BySearchQueryParam
{
    public int offset { get; set; }
    public int max { get; set; }
    public string data { get; set; } = "none";
    public string productDetail { get; set; } = "all";
    public string query { get; set; } = string.Empty;
}
namespace Application.Repositories.Nhtsa.Models;

public class ByYmmtQueryParam
{
    public string data { get; set; } = "crashtestratings,safetyfeatures,recommendedfeatures";
    public int modelYear { get; set; }
    public string series { get; set; } = string.Empty;
    public string make { get; set; } = string.Empty;
    public string model { get; set; } = string.Empty;
    public string trim { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
}
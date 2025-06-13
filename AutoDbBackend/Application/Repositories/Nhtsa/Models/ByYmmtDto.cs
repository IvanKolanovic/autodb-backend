using Application.Models;

namespace Application.Repositories.Nhtsa.Models;

public class ByYmmtDto
{
    public MetaDto Meta { get; set; }
    public List<ByYmmtDetails> Results { get; set; }
}

public class ByYmmtDetails : VehicleResultDto
{
    public SafetyRatings SafetyRatings { get; set; }
    public SafetyIssues SafetyIssues { get; set; }
}
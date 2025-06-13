#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Application.Repositories.Nhtsa.Models;

public class SafetyRatings
{
    public List<CrashTestRating> CrashTestRatings { get; set; }
    public List<SafetyFeatureCategory> SafetyFeatures { get; set; }
    public List<RecommendedFeature> RecommendedFeatures { get; set; }
}

public class CrashTestRating
{
    public string Type { get; set; }
    public string Display { get; set; }
    public string Mmy { get; set; }
    public int? NcapVehicleId { get; set; }
    public List<CrashRating> Ratings { get; set; }
}

public class CrashRating
{
    public string Position { get; set; }
    public string Display { get; set; }
    public string Rating { get; set; }
    public string Notes { get; set; }
    public string SafetyConcerns { get; set; }
    public List<CrashRating> Ratings { get; set; }
    public string Possibility { get; set; }
}

public class SafetyFeatureCategory
{
    public string Category { get; set; }
    public string Notes { get; set; }
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public string Label { get; set; }
    public string Value { get; set; }
    public string Notes { get; set; }
}

public class RecommendedFeature
{
    public string Key { get; set; }
    public string Label { get; set; }
    public string Video { get; set; }
    public string Icon { get; set; }
    public string Type { get; set; }
    public string NhtsaEvaluation { get; set; }
    public string NhtsaComments { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
}
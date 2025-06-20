using System.Text.Json.Serialization;

namespace Application.Repositories.Nhtsa.Models;

public class SafetyIssues
{
    [JsonPropertyName("complaints")]
    public List<Complaint> Complaints { get; set; } = [];

    [JsonPropertyName("recalls")]
    public List<Recall> Recalls { get; set; } = [];

    [JsonPropertyName("investigations")]
    public List<Investigation> Investigations { get; set; } = [];

    [JsonPropertyName("manufacturerCommunications")]
    public List<ManufacturerCommunication> ManufacturerCommunications { get; set; } = [];
}

public class Complaint
{
    [JsonPropertyName("dateFiled")]
    public DateTime DateFiled { get; set; }

    [JsonPropertyName("dateOfIncident")]
    public DateTime DateOfIncident { get; set; }

    [JsonPropertyName("nhtsaIdNumber")]
    public long NhtsaIdNumber { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("numberOfInjuries")]
    public int NumberOfInjuries { get; set; }

    [JsonPropertyName("numberOfDeaths")]
    public int NumberOfDeaths { get; set; }

    [JsonPropertyName("fire")]
    public bool Fire { get; set; }

    [JsonPropertyName("crash")]
    public bool Crash { get; set; }

    [JsonPropertyName("vin")]
    public string? Vin { get; set; }

    [JsonPropertyName("consumerLocation")]
    public string? ConsumerLocation { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("components")]
    public List<Component> Components { get; set; } = [];

    [JsonPropertyName("associatedDocumentsCount")]
    public int AssociatedDocumentsCount { get; set; }

    [JsonPropertyName("associatedDocuments")]
    public string? AssociatedDocuments { get; set; }

    [JsonPropertyName("associatedProductsCount")]
    public int AssociatedProductsCount { get; set; }

    [JsonPropertyName("associatedProducts")]
    public string? AssociatedProducts { get; set; }
}

public class Component
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

public class Recall
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("parkIt")]
    public bool ParkIt { get; set; }

    [JsonPropertyName("parkOutSide")]
    public bool ParkOutSide { get; set; }

    [JsonPropertyName("overTheAirUpdate")]
    public bool OverTheAirUpdate { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("mfrCampaignNumber")]
    public string? MfrCampaignNumber { get; set; }

    [JsonPropertyName("nhtsaCampaignNumber")]
    public string? NhtsaCampaignNumber { get; set; }

    [JsonPropertyName("reportReceivedDate")]
    public DateTime ReportReceivedDate { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("consequence")]
    public string? Consequence { get; set; }

    [JsonPropertyName("correctiveAction")]
    public string? CorrectiveAction { get; set; }

    [JsonPropertyName("potentialNumberOfUnitsAffected")]
    public int PotentialNumberOfUnitsAffected { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("associatedDocumentsCount")]
    public int AssociatedDocumentsCount { get; set; }

    [JsonPropertyName("associatedDocuments")]
    public string? AssociatedDocuments { get; set; }

    [JsonPropertyName("associatedProductsCount")]
    public int AssociatedProductsCount { get; set; }

    [JsonPropertyName("associatedProducts")]
    public string? AssociatedProducts { get; set; }

    [JsonPropertyName("components")]
    public List<Component> Components { get; set; } = [];

    [JsonPropertyName("investigations")]
    public List<Investigation> Investigations { get; set; } = [];
}

public class Investigation
{
    // Add fields if needed (currently empty in your JSON)
}

public class ManufacturerCommunication
{
    [JsonPropertyName("manufacturerCommunicationNumber")]
    public string? ManufacturerCommunicationNumber { get; set; }

    [JsonPropertyName("nhtsaIdNumber")]
    public long NhtsaIdNumber { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("communicationDate")]
    public DateTime CommunicationDate { get; set; }

    [JsonPropertyName("components")]
    public List<Component> Components { get; set; } = [];

    [JsonPropertyName("associatedDocumentsCount")]
    public int AssociatedDocumentsCount { get; set; }

    [JsonPropertyName("associatedDocuments")]
    public string? AssociatedDocuments { get; set; }

    [JsonPropertyName("associatedProductsCount")]
    public int AssociatedProductsCount { get; set; }

    [JsonPropertyName("associatedProducts")]
    public string? AssociatedProducts { get; set; }
}
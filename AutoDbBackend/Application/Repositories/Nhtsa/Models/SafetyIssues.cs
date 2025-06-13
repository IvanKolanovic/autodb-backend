namespace Application.Repositories.Nhtsa.Models;

public class SafetyIssues
{
    public List<Complaint> Complaints { get; set; }
    public List<Recall> Recalls { get; set; }
    public List<Investigation> Investigations { get; set; }
    public List<ManufacturerCommunication> ManufacturerCommunications { get; set; }
}

public class Complaint
{
    public DateTime DateFiled { get; set; }
    public DateTime DateOfIncident { get; set; }
    public long NhtsaIdNumber { get; set; }
    public long Id { get; set; }
    public int NumberOfInjuries { get; set; }
    public int NumberOfDeaths { get; set; }
    public bool Fire { get; set; }
    public bool Crash { get; set; }
    public string Vin { get; set; }
    public string ConsumerLocation { get; set; }
    public string Description { get; set; }
    public List<Component> Components { get; set; }
    public int AssociatedDocumentsCount { get; set; }
    public string AssociatedDocuments { get; set; }
    public int AssociatedProductsCount { get; set; }
    public string AssociatedProducts { get; set; }
}

public class Component
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class Recall
{
    public int Id { get; set; }
    public bool ParkIt { get; set; }
    public bool ParkOutSide { get; set; }
    public bool OverTheAirUpdate { get; set; }
    public string Manufacturer { get; set; }
    public string MfrCampaignNumber { get; set; }
    public string NhtsaCampaignNumber { get; set; }
    public DateTime ReportReceivedDate { get; set; }
    public string Subject { get; set; }
    public string Summary { get; set; }
    public string Consequence { get; set; }
    public string CorrectiveAction { get; set; }
    public int PotentialNumberOfUnitsAffected { get; set; }
    public string Notes { get; set; }
    public int AssociatedDocumentsCount { get; set; }
    public string AssociatedDocuments { get; set; }
    public int AssociatedProductsCount { get; set; }
    public string AssociatedProducts { get; set; }
    public List<Component> Components { get; set; }
    public List<Investigation> Investigations { get; set; }
}

public class Investigation
{
    // Add fields if needed (currently empty in your JSON)
}

public class ManufacturerCommunication
{
    public string ManufacturerCommunicationNumber { get; set; }
    public long NhtsaIdNumber { get; set; }
    public string Subject { get; set; }
    public string Summary { get; set; }
    public DateTime CommunicationDate { get; set; }
    public List<Component> Components { get; set; }
    public int AssociatedDocumentsCount { get; set; }
    public string AssociatedDocuments { get; set; }
    public int AssociatedProductsCount { get; set; }
    public string AssociatedProducts { get; set; }
}
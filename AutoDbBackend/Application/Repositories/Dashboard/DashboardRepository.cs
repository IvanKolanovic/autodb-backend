using System.Globalization;
using Application.Models;
using Application.Repositories.Dashboard;
using CsvHelper;
using CsvHelper.Configuration;

namespace Application.Repositories.Dashboard;

public class DashboardRepository : IDashboardRepository
{
    private readonly string _csvFilePath;

    public DashboardRepository(string csvFilePath)
    {
        _csvFilePath = csvFilePath;
    }

    public async Task<List<RecentRecallDto>> GetRecentRecalls(int count = 10)
    {
        try
        {
            if (!File.Exists(_csvFilePath))
            {
                Console.WriteLine($"CSV file not found at: {_csvFilePath}");
                return new List<RecentRecallDto>();
            }

            // Configure CSV reader
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                BadDataFound = null
            };

            // Use async file operations
            using var stream = new FileStream(_csvFilePath, FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true);
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, configuration);

            // Map CSV columns to DTO properties
            csv.Context.RegisterClassMap<RecallCsvMap>();

            // Read records asynchronously
            var records = new List<RecentRecallDto>();

            // Read the header row
            await csv.ReadAsync();
            csv.ReadHeader();

            // Read data rows
            while (await csv.ReadAsync())
            {
                var record = csv.GetRecord<RecentRecallDto>();
                if (record != null)
                {
                    records.Add(record);
                }
            }

            // Return most recent recalls (limited by count)
            return records.Take(count).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
            // Return empty list in case of error
            return new List<RecentRecallDto>();
        }
    }

    public async Task<List<ManufacturerRecallCountDto>> GetRecallsByManufacturer(int maxCount = 5)
    {
        try
        {
            // Get all recalls
            var allRecalls = await GetAllRecalls();

            // Group by manufacturer and count
            var recallsByManufacturer = allRecalls
                .GroupBy(r => r.Manufacturer)
                .Select(g => new ManufacturerRecallCountDto
                {
                    Manufacturer = g.Key,
                    RecallCount = g.Count()
                })
                .OrderByDescending(r => r.RecallCount)
                .Take(maxCount)
                .ToList();

            return recallsByManufacturer;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting recalls by manufacturer: {ex.Message}");
            return new List<ManufacturerRecallCountDto>();
        }
    }

    public async Task<List<MostRecalledVehicleDto>> GetMostRecalledVehicles(int maxCount = 5)
    {
        try
        {
            // Get all recalls
            var allRecalls = await GetAllRecalls();

            // Group by manufacturer and count
            var mostRecalled = allRecalls
                .GroupBy(r => r.Manufacturer)
                .Select(g => new MostRecalledVehicleDto
                {
                    Manufacturer = g.Key,
                    RecallCount = g.Count(),
                    IssueDescription = GetMainIssue(g.First())
                })
                .OrderByDescending(r => r.RecallCount)
                .Take(maxCount)
                .ToList();

            return mostRecalled;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting most recalled vehicles: {ex.Message}");
            return new List<MostRecalledVehicleDto>();
        }
    }

    private string GetMainIssue(RecentRecallDto recall)
    {
        // Return the subject if it's not empty, otherwise return the component
        return !string.IsNullOrEmpty(recall.Subject)
            ? recall.Subject
            : !string.IsNullOrEmpty(recall.Component)
                ? recall.Component
                : "Unknown Issue";
    }

    private async Task<List<RecentRecallDto>> GetAllRecalls()
    {
        if (!File.Exists(_csvFilePath))
        {
            Console.WriteLine($"CSV file not found at: {_csvFilePath}");
            return new List<RecentRecallDto>();
        }

        // Configure CSV reader
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            BadDataFound = null
        };

        // Use async file operations
        using var stream = new FileStream(_csvFilePath, FileMode.Open, FileAccess.Read, FileShare.Read,
            bufferSize: 4096, useAsync: true);
        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, configuration);

        // Map CSV columns to DTO properties
        csv.Context.RegisterClassMap<RecallCsvMap>();

        // Read records asynchronously
        var records = new List<RecentRecallDto>();

        // Read the header row
        await csv.ReadAsync();
        csv.ReadHeader();

        // Read data rows
        while (await csv.ReadAsync())
        {
            var record = csv.GetRecord<RecentRecallDto>();
            if (record != null)
            {
                records.Add(record);
            }
        }

        return records;
    }
}

public sealed class RecallCsvMap : ClassMap<RecentRecallDto>
{
    public RecallCsvMap()
    {
        Map(m => m.ReportReceivedDate).Name("Report Received Date");
        Map(m => m.NhtsaId).Name("NHTSA ID");
        Map(m => m.Manufacturer).Name("Manufacturer");
        Map(m => m.Subject).Name("Subject");
        Map(m => m.Component).Name("Component");
        Map(m => m.CampaignNumber).Name("Mfr Campaign Number");
        Map(m => m.RecallType).Name("Recall Type");
        Map(m => m.PotentiallyAffected).Name("Potentially Affected");
        Map(m => m.RecallDescription).Name("Recall Description");
        Map(m => m.ConsequenceSummary).Name("Consequence Summary");
        Map(m => m.CorrectiveAction).Name("Corrective Action");
        Map(m => m.ParkOutsideAdvisory).Name("Park Outside Advisory");
        Map(m => m.DoNotDriveAdvisory).Name("Do Not Drive Advisory");
        Map(m => m.CompletionRate).Name("Completion Rate % (Blank - Not Reported)");
    }
}
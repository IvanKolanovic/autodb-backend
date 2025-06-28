using System.Globalization;
using Application.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace Application.Repositories.Safety;

public class SafetyRepository : ISafetyRepository
{
    private readonly string _csvFilePath;

    public SafetyRepository(string csvFilePath)
    {
        _csvFilePath = csvFilePath;
    }

    public async Task<List<SafetyDataDto>> GetAllSafetyData()
    {
        try
        {
            if (!File.Exists(_csvFilePath))
            {
                Console.WriteLine($"CSV file not found at: {_csvFilePath}");
                return new List<SafetyDataDto>();
            }

            var safetyData = await ReadSafetyDataFromCsv();
            return safetyData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading safety data: {ex.Message}");
            return new List<SafetyDataDto>();
        }
    }

    public async Task<List<CrashTestPerformanceDto>> GetCrashTestPerformanceByManufacturer()
    {
        try
        {
            var safetyData = await GetAllSafetyData();

            // Group by manufacturer and calculate pass/fail rates
            var performanceData = safetyData
                .Where(d => d.OverallRating > 0) // Filter out entries without ratings
                .GroupBy(d => d.Manufacturer)
                .Select(g => new CrashTestPerformanceDto
                {
                    Manufacturer = g.Key,
                    TotalTests = g.Count(),
                    // Consider ratings of 4 or 5 as "Pass"
                    PassedTests = g.Count(d => d.OverallRating >= 4),
                    FailedTests = g.Count(d => d.OverallRating < 4 && d.OverallRating > 0),
                    PassRate = g.Count(d => d.OverallRating >= 4) / (double)g.Count()
                })
                .OrderByDescending(d => d.PassRate)
                .ToList();

            return performanceData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting crash test performance: {ex.Message}");
            return new List<CrashTestPerformanceDto>();
        }
    }

    public async Task<List<RolloverResistanceDto>> GetRolloverResistanceData()
    {
        try
        {
            var safetyData = await GetAllSafetyData();

            // Filter out entries without weight or rollover resistance data
            var resistanceData = safetyData
                .Where(d => d.Weight > 0 && d.RolloverResistance > 0)
                .Select(d => new RolloverResistanceDto
                {
                    Manufacturer = d.Manufacturer,
                    Model = d.Model,
                    Weight = d.Weight,
                    RolloverResistance = d.RolloverResistance
                })
                .ToList();

            return resistanceData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting rollover resistance data: {ex.Message}");
            return new List<RolloverResistanceDto>();
        }
    }

    private async Task<List<SafetyDataDto>> ReadSafetyDataFromCsv()
    {
        var safetyData = new List<SafetyDataDto>();

        // Use async file operations
        using var stream = new FileStream(_csvFilePath, FileMode.Open, FileAccess.Read, FileShare.Read,
            bufferSize: 4096, useAsync: true);
        using var reader = new StreamReader(stream);

        // Read the file line by line since the CSV structure is complex
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            try
            {
                // Parse the CSV line manually
                var fields = ParseCsvLine(line);
                if (fields.Length < 20) continue; // Skip lines with insufficient data

                var safetyItem = new SafetyDataDto
                {
                    Manufacturer = CleanField(fields[0]),
                    Model = CleanField(fields[1]),
                    Year = TryParseInt(CleanField(fields[2])),
                    BodyType = CleanField(fields[3]),
                    VehicleType = CleanField(fields[4]),
                    DriveType = CleanField(fields[5]),
                    Weight = ExtractWeight(fields),
                    OverallRating = ExtractOverallRating(fields),
                    FrontCrashRating = ExtractFrontCrashRating(fields),
                    SideCrashRating = ExtractSideCrashRating(fields),
                    RolloverRating = ExtractRolloverRating(fields),
                    RolloverResistance = ExtractRolloverResistance(fields),
                    HasTipped = ExtractHasTipped(fields)
                };

                // Only add items with valid data
                if (!string.IsNullOrEmpty(safetyItem.Manufacturer) &&
                    !string.IsNullOrEmpty(safetyItem.Model) &&
                    safetyItem.Year > 0)
                {
                    safetyData.Add(safetyItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing line: {ex.Message}");
                // Continue with next line
            }
        }

        return safetyData;
    }

    private string[] ParseCsvLine(string line)
    {
        var fields = new List<string>();
        bool inQuotes = false;
        int startIndex = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (line[i] == ',' && !inQuotes)
            {
                fields.Add(line.Substring(startIndex, i - startIndex));
                startIndex = i + 1;
            }
        }

        // Add the last field
        fields.Add(line.Substring(startIndex));

        return fields.ToArray();
    }

    private string CleanField(string field)
    {
        // Remove quotes and trim whitespace
        return field.Trim().Trim('"');
    }

    private int TryParseInt(string value)
    {
        if (int.TryParse(value, out int result))
        {
            return result;
        }
        return 0;
    }

    private double TryParseDouble(string value)
    {
        if (double.TryParse(value, out double result))
        {
            return result;
        }
        return 0;
    }

    private int ExtractWeight(string[] fields)
    {
        // Try to find weight in the fields (typically in position 12 or 13)
        for (int i = 12; i < Math.Min(fields.Length, 15); i++)
        {
            var weight = TryParseInt(CleanField(fields[i]));
            if (weight > 1000 && weight < 10000) // Reasonable weight range for vehicles
            {
                return weight;
            }
        }
        return 0;
    }

    private int ExtractOverallRating(string[] fields)
    {
        // Try to find overall rating (typically near position 9)
        for (int i = 8; i < Math.Min(fields.Length, 12); i++)
        {
            var rating = TryParseInt(CleanField(fields[i]));
            if (rating >= 1 && rating <= 5) // Ratings are typically 1-5
            {
                return rating;
            }
        }
        return 0;
    }

    private int ExtractFrontCrashRating(string[] fields)
    {
        // Search for front crash rating in various positions
        for (int i = 50; i < Math.Min(fields.Length, 100); i++)
        {
            var rating = TryParseInt(CleanField(fields[i]));
            if (rating >= 1 && rating <= 5)
            {
                return rating;
            }
        }
        return 0;
    }

    private int ExtractSideCrashRating(string[] fields)
    {
        // Search for side crash rating in various positions
        for (int i = 70; i < Math.Min(fields.Length, 120); i++)
        {
            var rating = TryParseInt(CleanField(fields[i]));
            if (rating >= 1 && rating <= 5)
            {
                return rating;
            }
        }
        return 0;
    }

    private int ExtractRolloverRating(string[] fields)
    {
        // Search for rollover rating in various positions
        for (int i = 90; i < Math.Min(fields.Length, 140); i++)
        {
            var rating = TryParseInt(CleanField(fields[i]));
            if (rating >= 1 && rating <= 5)
            {
                return rating;
            }
        }
        return 0;
    }

    private double ExtractRolloverResistance(string[] fields)
    {
        // Search for rollover resistance value (typically a decimal between 0 and 1)
        for (int i = fields.Length - 30; i < fields.Length; i++)
        {
            if (i < 0) continue;

            var value = CleanField(fields[i]);
            if (value.StartsWith(".") || (value.Length <= 4 && value.Contains(".")))
            {
                var resistance = TryParseDouble(value);
                if (resistance > 0 && resistance < 1) // Typical range for rollover resistance
                {
                    return resistance;
                }
            }
        }
        return 0;
    }

    private bool ExtractHasTipped(string[] fields)
    {
        // Search for "Tip" or "No Tip" indicators
        for (int i = fields.Length - 20; i < fields.Length; i++)
        {
            if (i < 0) continue;

            var value = CleanField(fields[i]);
            if (value.Contains("Tip"))
            {
                return !value.Contains("No Tip");
            }
        }
        return false;
    }
}
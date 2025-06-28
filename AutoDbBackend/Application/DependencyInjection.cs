using System.Reflection;
using System.Text.Json;
using Application.Common.Behaviours;
using Application.Repositories.Dashboard;
using Application.Repositories.Nhtsa;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        // Add FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Register DashboardRepository with absolute path to CSV file
        var csvFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Infrastructure", "Data", "recall_data.csv"));

        // If that doesn't exist, try another path
        if (!File.Exists(csvFilePath))
        {
            csvFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "AutoDbBackend", "Infrastructure", "Data", "recall_data.csv"));
        }

        Console.WriteLine($"Registering DashboardRepository with CSV file path: {csvFilePath}");
        services.AddScoped<IDashboardRepository>(provider => new DashboardRepository(csvFilePath));

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        // Create RefitSettings
        var settings = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(options),
        };

        // Add Refit
        services.AddRefitClient<INhtsaRepository>(settings).ConfigureHttpClient((sp, httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://api.nhtsa.gov");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Nhtsa API");
        });

        return services;
    }
}
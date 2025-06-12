using System.Reflection;
using System.Text.Json;
using Application.Common.Behaviours;
using Application.Repositories.Nhtsa;
using FluentValidation;
using MediatR;
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
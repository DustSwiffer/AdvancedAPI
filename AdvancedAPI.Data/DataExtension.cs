using AdvancedAPI.Data.Repositories;
using AdvancedAPI.Data.Repositories.Interfaces;

namespace AdvancedAPI.Data;

/// <summary>
/// Service extension used to prepare the data layer for usage.
/// </summary>
public static class DataExtension
{
    /// <summary>
    /// Registers everything data layer related.
    /// </summary>
    public static void AddDataRepositories(this IServiceCollection services)
    {
        services.AddScoped<IIdentityRepository, IdentityRepository>();
        services.AddScoped<INewsArticleRepository, NewsArticleRepository>();
        services.AddScoped<IGenderRepository, GenderRepository>();
        services.AddScoped<ILastSeenRepository, LastSeenRepository>();
    }
}

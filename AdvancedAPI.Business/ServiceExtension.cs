using Business.Services;
using Business.Services.Interfaces;

namespace Business;

/// <summary>
/// Service extension used to prepare the business layer for usage.
/// </summary>
public static class ServiceExtension
{
    /// <summary>
    /// Registers everything business layer related.
    /// </summary>
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<INewsArticleService, NewsArticleService>();

        return services;
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace Template.Core;

public static class DomainModule
{
    public static IServiceCollection AddDomainModule(this IServiceCollection services)
    {
        services.AddDomainServices();

        return services;
    }

    private static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        // ? Example
        // services.AddScoped<ICryptoService, CryptoService>();

        return services;
    }
}

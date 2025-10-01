using Microsoft.Extensions.DependencyInjection;

namespace Template.Core;

public static class DomainModule
{
    public static IServiceCollection AddDomainModule(this IServiceCollection services)
    {
        // services.AddDomainServices();

        return services;
    }
}

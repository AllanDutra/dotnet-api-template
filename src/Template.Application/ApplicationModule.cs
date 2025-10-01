using Microsoft.Extensions.DependencyInjection;

namespace Template.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        // services.AddNotifications().AddApplications();

        return services;
    }
}

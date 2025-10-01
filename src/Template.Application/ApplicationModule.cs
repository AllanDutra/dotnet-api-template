using Microsoft.Extensions.DependencyInjection;
using Template.Application.Notifications;
using Template.Core.Interfaces.Notifications;

namespace Template.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddNotifications().AddApplications();

        return services;
    }

    private static IServiceCollection AddNotifications(this IServiceCollection services)
    {
        services.AddScoped<INotifier, Notifier>();

        return services;
    }

    private static IServiceCollection AddApplications(this IServiceCollection services)
    {
        // ? Example
        // services.AddScoped<IAddClientApplication, AddClientApplication>();

        return services;
    }
}

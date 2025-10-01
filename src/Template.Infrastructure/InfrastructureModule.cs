using Microsoft.Extensions.DependencyInjection;

namespace Template.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        // ? Example
        // services.AddDbContext<ClientsContext>(p =>
        //     p.UseNpgsql(Variables.Contexts.Clients.ConnectionString)
        // );

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // ? Example
        // services.AddScoped<IClientRepository, ClientRepository>();

        return services;
    }
}

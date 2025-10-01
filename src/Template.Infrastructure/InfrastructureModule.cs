namespace Template.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        // services.AddDbContext<AnunciosContext>(p =>
        //     p.UseNpgsql(Variaveis.Contextos.Anuncios.ConnectionString)
        // );

        // services
        //     .AddRepositories()
        //     .AddStorages();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // ? Example
        // services.AddScoped<IClientRepository, ClientRepository>();

        return services;
    }
}

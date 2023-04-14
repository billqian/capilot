namespace Syntop.Pilot.Infrastructure;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration config)
    {
        //var assembly = typeof(DependencyInjectionExtension).Assembly;

        //services.AddMediatR(config => {
        //    config.RegisterServicesFromAssembly(assembly);
        //});

        return services;
    }
}

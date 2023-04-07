using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Pilot.WebAPI;

public static class ConfigureServices
{

    public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
    {
        //mapper
        var mapperConfig = new TypeAdapterConfig();   // Or var mapperConfig = TypeAdapterConfig.GlobalSettings;
        mapperConfig.Scan(
            typeof(Program).Assembly, 
            typeof(Application.ConfigureServices).Assembly,
            typeof(Infrastructure.ConfigureServices).Assembly);
        services.AddSingleton(mapperConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddMediatR((cfg) => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}
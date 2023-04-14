using Mapster;
using MapsterMapper;
using MediatR.NotificationPublishers;
using Syntop.Pilot.Application.Behaviors;

namespace Syntop.Pilot.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services, 
        IConfiguration config)
    {
        var assembly = typeof(DependencyInjectionExtension).Assembly;

        services.AddValidatorsFromAssembly(assembly);
        //to do: add options if necessary

        services.AddMediatR(config => {
            config.RegisterServicesFromAssembly(assembly);

            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionLoggerBehavior<,>));
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            config.NotificationPublisher = new TaskWhenAllPublisher();  //ForeachAwaitPublisher, 处理程序并行
        });

        RegisterMapster(services);

        return services;
    }

    private static IServiceCollection RegisterMapster(IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        // Or
        // var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(DependencyInjectionExtension).Assembly);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}

using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using Syntop.Pilot.Application.Behaviors;
using Syntop.Pilot.Pesistence.Interceptors;

namespace Syntop.Pilot.Pesistence;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddPesistenceServices(
        this IServiceCollection services, 
        IConfiguration config)
    {
        services.AddScoped<DemoSaveChangesInterceptor>();

        //services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseNpgsql(config.GetConnectionString("DefaultConnection"),
        //        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(config.GetConnectionString("LocalConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


        services.AddScoped<IApplicationDbContext>(
            sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        return services;
    }
}

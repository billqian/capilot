using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public static class ConfigureServices
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR((cfg) => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}

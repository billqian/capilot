﻿namespace Syntop.Pilot.WebApi;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddWebApiServices(
        this IServiceCollection services, 
        IConfiguration config)
    {
        services.AddHttpContextAccessor();
        return services;
    }
}

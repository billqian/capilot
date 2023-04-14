using Microsoft.Extensions.Options;

namespace Syntop.Pilot.Application.Extensions.Options;

public static class FluentValidationOptionExtensions
{
    public static IServiceCollection AddOptionsWithFluentValidation<TOptions, TValidator>(this IServiceCollection services,
        IConfiguration config, string configSectionName = "")
        where TOptions : class
        where TValidator : AbstractOptionsValidator<TOptions>, new()
    {
        if (string.IsNullOrWhiteSpace(configSectionName)) {
            configSectionName = typeof(TOptions).Name;
        }
        services.AddOptions<TOptions>().Configure(options => {
            config.GetSection(configSectionName).Bind(options);
        }).Services.AddSingleton<IValidateOptions<TOptions>, TValidator>();

        return services;
    }
}
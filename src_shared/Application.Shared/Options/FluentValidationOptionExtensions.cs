using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Application.Shared.Options;

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
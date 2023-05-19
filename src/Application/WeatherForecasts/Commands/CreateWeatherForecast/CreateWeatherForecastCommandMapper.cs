using Mapster;
using Syntop.Pilot.Domain.Demo;

namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

internal class CreateWeatherForecastCommandMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateWeatherForecastCommand, WeatherForecast>()
            ;
    }
}

using Syntop.Pilot.Dto.WeatherForecasts;

namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

public class CreateWeatherForecastCommand
    : CreateWeatherForecastCommandData,
    IRequest<Guid>
{ }

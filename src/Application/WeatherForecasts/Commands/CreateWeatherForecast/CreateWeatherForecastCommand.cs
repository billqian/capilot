using Syntop.Pilot.Dto.WeatherForecasts;

namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

public record CreateWeatherForecastCommand(CreateWeatherForecastRequest Item) 
    : IRequest<Guid>;
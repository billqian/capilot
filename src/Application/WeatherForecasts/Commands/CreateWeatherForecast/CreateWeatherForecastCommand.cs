using Syntop.Pilot.Application.RequestModels.WeatherForecasts;

namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

public record CreateWeatherForecastCommand(DateOnly Date, int TemperatureC, string? Summary)
    : CreateWeatherForecastCommandData(Date, TemperatureC, Summary),
    IRequest<Guid>;

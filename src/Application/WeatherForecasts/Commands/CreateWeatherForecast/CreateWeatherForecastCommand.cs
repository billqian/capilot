namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

public record CreateWeatherForecastCommand(
    DateOnly Date, 
    int TemperatureC, 
    string? Summary = "") : IRequest<Guid>;

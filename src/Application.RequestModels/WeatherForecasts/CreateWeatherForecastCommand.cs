using Syntop.Pilot.Dto.WeatherForecasts;

namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

public record CreateWeatherForecastCommand() 
    : IRequest<Guid>
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}
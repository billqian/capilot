using Syntop.Pilot.Application.Services;
using Syntop.Pilot.Domain.Demo;

namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

internal class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, Guid>
{

    private readonly IApplicationDbContext _context;

    public CreateWeatherForecastCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
    {
        var forecastItem = new WeatherForecast() {
            Date = request.Date,
            Summary = request.Summary,
            TemperatureC = request.TemperatureC
        };

        await _context.WeatherForecasts.AddAsync(forecastItem);

        await _context.SaveChangesAsync(cancellationToken);

        return forecastItem.Id;
    }
}
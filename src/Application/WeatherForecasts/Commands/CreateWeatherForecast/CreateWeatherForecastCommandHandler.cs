using Syntop.Pilot.Application.Services;
using Syntop.Pilot.Domain.Demo;

namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

internal class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, Guid>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateWeatherForecastCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
    {
        var forecastItem = _mapper.Map<WeatherForecast>(request);

        forecastItem.AddDomainEvent(
            new WeatherForecastCreatedEvent() { 
                Target = forecastItem 
            });
        await _context.WeatherForecasts.AddAsync(forecastItem);

        await _context.SaveChangesAsync(cancellationToken);

        return forecastItem.Id;
    }
}
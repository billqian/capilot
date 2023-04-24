using Syntop.Pilot.Application.Services;
using Syntop.Pilot.Domain.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Application.WeatherForecasts.EventHandlers;

internal class WeatherForecastCreatedEventHandler
    : INotificationHandler<WeatherForecastCreatedEvent>
{
    private readonly IApplicationDbContext _context;
    public WeatherForecastCreatedEventHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(WeatherForecastCreatedEvent notification, CancellationToken cancellationToken)
    {
        var targetItem = notification.Target;
        if (targetItem != null 
            && !_context.City.Any(item => item.CityName == targetItem.Summary)) {
            await _context.City.AddAsync(new City() { 
                CityName = targetItem.Summary
            });

        }
    }
}

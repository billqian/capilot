using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Domain.Demo;

public class WeatherForecastCreatedEvent : BaseEvent
{
    public WeatherForecast? Target { get; set; }
}

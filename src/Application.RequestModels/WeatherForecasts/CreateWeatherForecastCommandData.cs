using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Dto.WeatherForecasts;

public class CreateWeatherForecastCommandData
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}

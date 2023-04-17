using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Dto.WeatherForecasts;

public record CreateWeatherForecastCommandData(DateOnly Date,
    int TemperatureC,
    string? Summary = "");

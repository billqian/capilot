using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Application.RequestModels.WeatherForecasts;

public record CreateWeatherForecastCommandData(DateOnly Date,
    int TemperatureC,
    string? Summary = "");

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

public record CreateWeatherForecastCommand(
    DateOnly Date, 
    int TemperatureC, 
    string? Summary = "") : IRequest<Guid>;

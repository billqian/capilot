using Mapster;
using Syntop.Pilot.Application.WeatherForecasts.Queries.GetAll;
using Syntop.Pilot.Domain.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

internal class CreateWeatherForecastCommandMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateWeatherForecastCommand, WeatherForecast>()
            ;
    }
}

using Mapster;
using Syntop.Pilot.Application.RequestModels.WeatherForecasts;
using Syntop.Pilot.Domain.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Application.WeatherForecasts.Queries.GetAll;

internal class GetAllItemQueryResponseItemMapsterRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<WeatherForecast, GetAllItemQueryResponseItem>()
            .Map(dest => dest.Temperature, src => src.TemperatureC)
            .Map(dest => dest.TemperatureFahrenheit, src => src.TemperatureF);
    }
}

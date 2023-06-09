﻿using Mapster;
using Syntop.Pilot.Dto.WeatherForecasts;
using Syntop.Pilot.Domain.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Application.WeatherForecasts.Queries.GetAll;

internal class GetAllItemsQueryResponseItemMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<WeatherForecast, GetAllItemsResponseItem>()
            .Map(dest => dest.Temperature, src => src.TemperatureC)
            .Map(dest => dest.TemperatureFahrenheit, src => src.TemperatureF);
    }
}

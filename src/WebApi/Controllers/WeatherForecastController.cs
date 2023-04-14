using Microsoft.AspNetCore.Mvc;
using Syntop.Pilot.Application.RequestModels.WeatherForecasts;
using Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;
using Syntop.Pilot.Application.WeatherForecasts.Queries.GetAll;
using Syntop.Pilot.Domain.Demo;

namespace Syntop.Pilot.WebApi.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<GetAllItemQueryResponse> Get()
    {
        return await Sender.Send(new GetAllItemsQuery());
    }

    [HttpPost]
    public async Task<Guid> Post(CreateWeatherForecastCommand cmd)
    {
        return await Sender.Send(cmd);
    }
}

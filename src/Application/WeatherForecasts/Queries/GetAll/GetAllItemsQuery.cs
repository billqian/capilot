using Syntop.Pilot.Application.RequestModels.WeatherForecasts;

namespace Syntop.Pilot.Application.WeatherForecasts.Queries.GetAll;

public record GetAllItemsQuery() : IRequest<GetAllItemQueryResponse>;


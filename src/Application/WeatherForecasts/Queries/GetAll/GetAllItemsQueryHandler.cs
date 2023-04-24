using Mapster;
using Microsoft.EntityFrameworkCore;
using Syntop.Pilot.Dto.WeatherForecasts;
using Syntop.Pilot.Application.Services;
using Syntop.Pilot.Domain.Demo;

namespace Syntop.Pilot.Application.WeatherForecasts.Queries.GetAll;

internal class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, GetAllItemsResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllItemsQueryHandler(
        IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Task<GetAllItemsResponse> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var items =
        _context.WeatherForecast
        .AsNoTracking()
        .OrderBy(x => x.Date)
        .ProjectToType<GetAllItemsResponseItem>(_mapper.Config)
        .AsEnumerable();
        return Task.FromResult(new GetAllItemsResponse(
            TotalCount: items.Count(),
            Items: items
        ));
    }
}

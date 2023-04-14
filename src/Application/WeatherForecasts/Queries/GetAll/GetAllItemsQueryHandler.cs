using Mapster;
using Microsoft.EntityFrameworkCore;
using Syntop.Pilot.Application.Services;
using Syntop.Pilot.Domain.Demo;

namespace Syntop.Pilot.Application.WeatherForecasts.Queries.GetAll;

internal class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, GetAllItemQueryResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllItemsQueryHandler(
        IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Task<GetAllItemQueryResponse> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var items =
        _context.WeatherForecasts
        .AsNoTracking()
        .OrderBy(x => x.Date)
        .ProjectToType<GetAllItemQueryResponseItem>(_mapper.Config)
        .AsEnumerable();
        return Task.FromResult(new GetAllItemQueryResponse(
            TotalCount: items.Count(),
            Items: items
        ));
    }
}

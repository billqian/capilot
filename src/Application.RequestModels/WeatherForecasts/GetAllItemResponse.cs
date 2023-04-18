using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Dto.WeatherForecasts;

public record GetAllItemsResponse(int TotalCount, IEnumerable<GetAllItemsResponseItem> Items);

public class GetAllItemsResponseItem
{
    public DateOnly Date { get; set; }
    public int Temperature { get; set; }
    public int TemperatureFahrenheit { get; set; }
    public string? Summary { get; set; }
}
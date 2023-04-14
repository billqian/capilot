﻿using Syntop.Pilot.Domain.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Application.WeatherForecasts.Queries.GetAll;

public record GetAllItemsQuery() : IRequest<GetAllItemQueryResponse>;


public record GetAllItemQueryResponse(int TotalCount, IEnumerable<GetAllItemQueryResponseItem> Items);

public class GetAllItemQueryResponseItem {
    public DateOnly Date { get; set; }
    public int Temperature { get; set; }
    public int TemperatureFahrenheit { get; set; }
    public string? Summary { get; set; }
}
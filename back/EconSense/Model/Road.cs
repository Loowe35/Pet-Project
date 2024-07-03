using System;
using System.Collections.Generic;

namespace EconSense.Model;

public partial class Road
{
    public int RoadId { get; set; }

    public string? RoadName { get; set; }

    public decimal? RoadLength { get; set; }

    public string? ArrivalPoint { get; set; }

    public virtual ICollection<RouteSection> RouteSections { get; set; } = new List<RouteSection>();
}

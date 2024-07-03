using System;
using System.Collections.Generic;

namespace EconSense.Model;

public partial class Route
{
    public int RouteId { get; set; }

    public string? RouteName { get; set; }

    public string? StartingPoint { get; set; }

    public string? EndingPoint { get; set; }

    public decimal? RouteLength { get; set; }

    public virtual ICollection<RouteSection> RouteSections { get; set; } = new List<RouteSection>();

    public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}

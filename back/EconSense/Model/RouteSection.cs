using System;
using System.Collections.Generic;

namespace EconSense.Model;

public partial class RouteSection
{
    public int RouteSectionId { get; set; }

    public int? RouteNumber { get; set; }

    public int? RoadNumber { get; set; }

    public virtual Road? RoadNumberNavigation { get; set; }

    public virtual Route? RouteNumberNavigation { get; set; }
}

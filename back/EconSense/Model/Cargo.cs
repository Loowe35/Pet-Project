using System;
using System.Collections.Generic;

namespace EconSense.Model;

public partial class Cargo
{
    public int CargoId { get; set; }

    public string? CargoName { get; set; }

    public decimal? Volume { get; set; }

    public decimal? Weight { get; set; }

    public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}

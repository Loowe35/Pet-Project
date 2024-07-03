using System;
using System.Collections.Generic;

namespace EconSense.Model;

public partial class Transport
{
    public int TransportId { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public DateOnly? YearOfRelease { get; set; }

    public string? LicensePlate { get; set; }

    public decimal? BodyVolume { get; set; }

    public decimal? AverageFuelConsumption { get; set; }

    public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}

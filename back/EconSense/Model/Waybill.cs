using System;
using System.Collections.Generic;

namespace EconSense.Model;

public partial class Waybill
{
    public int WaybillId { get; set; }

    public int? DriverNumber { get; set; }

    public int? TransportNumber { get; set; }

    public int? RouteNumber { get; set; }

    public int? CargoNumber { get; set; }

    public int? UserNumber { get; set; }

    public DateOnly? DepartureDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }

    public byte[]? Photo { get; set; }

    public string? Comment { get; set; }

    public string? Status { get; set; }

    public virtual Cargo? CargoNumberNavigation { get; set; }

    public virtual Driver? DriverNumberNavigation { get; set; }

    public virtual Route? RouteNumberNavigation { get; set; }

    public virtual ICollection<TransportExpense> TransportExpenses { get; set; } = new List<TransportExpense>();

    public virtual Transport? TransportNumberNavigation { get; set; }

    public virtual User? UserNumberNavigation { get; set; }
}

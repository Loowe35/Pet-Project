using System;
using System.Collections.Generic;

namespace EconSense.Model;

public partial class TransportExpense
{
    public int ExpenseId { get; set; }

    public int? WaybillId { get; set; }

    public decimal? Fuel { get; set; }

    public decimal? MaintenanceAndRepair { get; set; }

    public decimal? ForcedDowntime { get; set; }

    public decimal? LossesDueToDowntime { get; set; }

    public virtual Waybill? Waybill { get; set; }
}

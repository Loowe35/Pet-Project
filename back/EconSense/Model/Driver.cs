using System;
using System.Collections.Generic;

namespace EconSense.Model;

public partial class Driver
{
    public int DriverId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public string? PassportSeriesAndNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateOnly? DrivingLicenseExpiryDate { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}

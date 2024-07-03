using System;
using System.Collections.Generic;

namespace EconSense.Model;

public partial class User
{
    public int UserId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? PassportSeriesAndNumber { get; set; }

    public string? PlaceOfResidence { get; set; }

    public string? ActualResidentialAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Position { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}

using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class EmplyeeBroadband
{
    public int AnstNr { get; set; }

    public string? Supplier { get; set; }

    public string? SubscriptionType { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Pin { get; set; }

    public string? Puk { get; set; }

    public string? HardwareType { get; set; }

    public string? HardwareSn { get; set; }

    public int Antal { get; set; }
}

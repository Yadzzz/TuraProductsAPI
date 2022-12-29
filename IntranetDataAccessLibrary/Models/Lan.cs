using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class Lan
{
    public string Ipaddress { get; set; } = null!;

    public string? Service { get; set; }

    public string? Info { get; set; }
}

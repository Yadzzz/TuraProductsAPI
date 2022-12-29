using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class Dmz
{
    public string Ipaddress { get; set; } = null!;

    public string? Service { get; set; }

    public string? SubnetMask { get; set; }
}

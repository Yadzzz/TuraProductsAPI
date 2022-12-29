using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class VmotionNet
{
    public string Ipaddress { get; set; } = null!;

    public string? Appliance { get; set; }

    public string? Interface { get; set; }
}

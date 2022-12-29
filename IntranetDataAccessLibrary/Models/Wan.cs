using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class Wan
{
    public int Id { get; set; }

    public string? Ipaddress { get; set; }

    public string? Service { get; set; }

    public string? Misc { get; set; }
}

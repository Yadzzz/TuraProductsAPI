using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class San
{
    public string? HardwareType { get; set; }

    public string? Product { get; set; }

    public string? IfE0a { get; set; }

    public string? IfE0b { get; set; }

    public string? Bmc { get; set; }

    public string? Sn { get; set; }

    public int Id { get; set; }
}

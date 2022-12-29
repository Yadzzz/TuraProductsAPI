using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class Dn
{
    public int Id { get; set; }

    public string? Host { get; set; }

    public string? Type { get; set; }

    public string? TdcDestination { get; set; }

    public string? TeliaDestination { get; set; }
}

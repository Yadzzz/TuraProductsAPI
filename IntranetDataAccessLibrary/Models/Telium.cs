using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class Telium
{
    public int Id { get; set; }

    public string? Interface { get; set; }

    public string? Telia { get; set; }

    public string? CiscoInt { get; set; }
}

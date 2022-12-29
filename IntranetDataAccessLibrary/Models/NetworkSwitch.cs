using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class NetworkSwitch
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int LocationId { get; set; }

    public string? Placement { get; set; }
}

using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class SwitchPort
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? AssignedTo { get; set; }

    public int NetworkSwitchId { get; set; }
}

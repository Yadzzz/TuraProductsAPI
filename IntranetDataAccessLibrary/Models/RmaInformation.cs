using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class RmaInformation
{
    public int Id { get; set; }

    public string ItemNumber { get; set; } = null!;

    public string? Rmainfo { get; set; }
}

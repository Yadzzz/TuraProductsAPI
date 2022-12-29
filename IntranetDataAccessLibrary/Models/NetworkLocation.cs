using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class NetworkLocation
{
    public int Id { get; set; }

    public string Location { get; set; } = null!;
}

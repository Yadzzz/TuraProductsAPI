using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class Passwd
{
    public string? Appliance { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int Id { get; set; }
}

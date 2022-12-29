using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class NetworkIp
{
    public int Id { get; set; }

    public int Ip1 { get; set; }

    public int Ip2 { get; set; }

    public int Ip3 { get; set; }

    public int Ip4 { get; set; }

    public string? AssignedTo { get; set; }

    public string? Info { get; set; }

    public int NetworkId { get; set; }
}

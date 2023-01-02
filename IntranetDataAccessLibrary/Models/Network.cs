using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class Network
{
    public int Id { get; set; }

    public string NetworkName { get; set; } = null!;

    public string? Address { get; set; }

    public string? SubnetAddress { get; set; }

    public string? VlanId { get; set; }

    public virtual ICollection<NetworkIp> NetworkIps { get; } = new List<NetworkIp>();
}

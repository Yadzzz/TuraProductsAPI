using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class HardWareInfo
{
    public int Id { get; set; }

    public string? Interface { get; set; }

    public string? InterfaceIp { get; set; }

    public string? Switch { get; set; }

    public string? PortRedundancy { get; set; }

    public string? MachineModel { get; set; }

    public string? Os { get; set; }

    public string? Cpu { get; set; }

    public string? Memory { get; set; }

    public string? Location { get; set; }
}

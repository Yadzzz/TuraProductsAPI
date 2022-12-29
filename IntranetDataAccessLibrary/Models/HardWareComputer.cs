using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class HardWareComputer
{
    public int Id { get; set; }

    public string? ComputerName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? ComputerModel { get; set; }

    public string? ComputerType { get; set; }

    public string? Misc { get; set; }

    public DateTime? Delivered { get; set; }

    public string? Profile { get; set; }
}

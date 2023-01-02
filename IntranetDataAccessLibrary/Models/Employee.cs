using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class Employee
{
    public int Antal { get; set; }

    public string? Efternamn { get; set; }

    public string? Förnamn { get; set; }

    public string? Arbetsuppgift { get; set; }

    public string? Attest { get; set; }

    public string? Land { get; set; }

    public DateTime? Anställd { get; set; }

    public string? AnstForm { get; set; }

    public int AnstNr { get; set; }

    public string? Avtal { get; set; }

    public string? Arbetsställe { get; set; }

    public string? Kön { get; set; }

    public virtual EmplyeeBroadband? EmplyeeBroadband { get; set; }
}

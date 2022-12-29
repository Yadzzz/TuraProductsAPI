using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class SoftwareLicense
{
    public string? Företag { get; set; }

    public string? Mjukvara { get; set; }

    public string? Version { get; set; }

    public string? Språk { get; set; }

    public int? Antal { get; set; }

    public string? Plattform { get; set; }

    public string? SrNr { get; set; }

    public string? Media { get; set; }

    public string? Leverantör { get; set; }

    public int Id { get; set; }

    public bool? VolymLicens { get; set; }
}

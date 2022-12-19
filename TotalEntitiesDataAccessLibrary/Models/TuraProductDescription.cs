using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class TuraProductDescription
{
    public string ItemNumber { get; set; } = null!;

    public string? Ean { get; set; }

    public string? ManufacturerCode { get; set; }

    public string? Name { get; set; }

    public string? English { get; set; }

    public string? Swedish { get; set; }

    public string? Danish { get; set; }

    public string? Finnish { get; set; }

    public string? Norwegian { get; set; }
}

using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class VatPostingSetup
{
    public byte[] Timestamp { get; set; } = null!;

    public string VatBusPostingGroup { get; set; } = null!;

    public string VatProdPostingGroup { get; set; } = null!;

    public int VatCalculationType { get; set; }

    public decimal Vat { get; set; }
}

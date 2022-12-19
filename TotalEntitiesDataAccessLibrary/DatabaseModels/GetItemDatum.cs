using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class GetItemDatum
{
    public string No { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string VendorItemNo { get; set; } = null!;

    public string PrimaryEanCode { get; set; } = null!;

    public string? ManufacturerCode { get; set; }

    public string? ActivityCode { get; set; }

    public string? UnspscId { get; set; }

    public string? UnspscName { get; set; }

    public string? ItemDescriptionSw { get; set; }
}

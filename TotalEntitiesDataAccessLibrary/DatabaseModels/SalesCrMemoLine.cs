using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class SalesCrMemoLine
{
    public byte[] Timestamp { get; set; } = null!;

    public string DocumentNo { get; set; } = null!;

    public int LineNo { get; set; }

    public string No { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public string ItemCategoryCode { get; set; } = null!;

    public decimal? OrderQuantity { get; set; }

    public string? YourOrderNo { get; set; }

    public string? Description { get; set; }

    public string? Description2 { get; set; }
}

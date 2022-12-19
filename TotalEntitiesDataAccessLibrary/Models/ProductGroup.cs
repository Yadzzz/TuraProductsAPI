using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class ProductGroup
{
    public byte[] Timestamp { get; set; } = null!;

    public string ItemCategoryCode { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? WarehouseClassCode { get; set; }
}

using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class ProductGroup
{
    public byte[] Timestamp { get; set; } = null!;

    public string ItemCategoryCode { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? WarehouseClassCode { get; set; }
}

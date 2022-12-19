using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class ItemStockDatum
{
    public byte[] Timestamp { get; set; } = null!;

    public string ItemNo { get; set; } = null!;

    public decimal AvailableQantity { get; set; }

    public decimal? ReservedQuantity { get; set; }

    public decimal? QuantityOnInventory { get; set; }

    public decimal? QuantityOnPurchaseOrder { get; set; }

    public decimal? QuantityOnSalesOrder { get; set; }
}

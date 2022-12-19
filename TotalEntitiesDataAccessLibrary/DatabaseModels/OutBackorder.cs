using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class OutBackorder
{
    public string CustomerNo { get; set; } = null!;

    public string SalesItemNo { get; set; } = null!;

    public string OrderNo { get; set; } = null!;

    public int PositionNo { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal OrderedQuantity { get; set; }

    public decimal BackorderQuantity { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal NetListprice { get; set; }

    public string SuggestedRetailPrice { get; set; } = null!;

    public string WeekDelivery { get; set; } = null!;

    public string YearDelivery { get; set; } = null!;

    public string OrderDaet2 { get; set; } = null!;

    public string OrderText { get; set; } = null!;

    public string LastModified { get; set; } = null!;
}

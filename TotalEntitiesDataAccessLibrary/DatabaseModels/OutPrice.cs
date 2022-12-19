using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class OutPrice
{
    public string SalesItemNo { get; set; } = null!;

    public string Pricetype { get; set; } = null!;

    public decimal Price { get; set; }

    public string InvCurrency { get; set; } = null!;

    public decimal Quantity { get; set; }
}

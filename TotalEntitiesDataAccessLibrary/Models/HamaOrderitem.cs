using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class HamaOrderitem
{
    public int OrderitemId { get; set; }

    public int PurchaseorderId { get; set; }

    public int? ItemId { get; set; }

    public int? CurrencyId { get; set; }

    public string? Itemnumber { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public string? Note { get; set; }

    public int RecordstatusId { get; set; }

    public DateTime LastModified { get; set; }
}

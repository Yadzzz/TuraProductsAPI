using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class InBackorder
{
    public string CustomerNo { get; set; } = null!;

    public string SalesItemNo { get; set; } = null!;

    public string OrderNumberInternal { get; set; } = null!;

    public int OrderLine { get; set; }

    public string? OrderDate { get; set; }

    public int? OrderQty { get; set; }

    public int? OrderQtyBackorder { get; set; }

    public decimal? CustomerBuyingPrice { get; set; }

    public int? Price { get; set; }

    public int PriceTypeId { get; set; }

    public int? PriceSrp { get; set; }

    public int? WeekDelivery { get; set; }

    public int? YearDelivery { get; set; }

    public int? OrderText { get; set; }

    public int? LastModified { get; set; }

    public int OwnerId { get; set; }

    public string? TransmissionDate { get; set; }
}

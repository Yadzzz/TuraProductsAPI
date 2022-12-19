using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class InSalesLineOrderhistory
{
    public int InvoiceTypeId { get; set; }

    public string CustomerNo { get; set; } = null!;

    public int? CustomerLevel3 { get; set; }

    public string OrderNumberInternal { get; set; } = null!;

    public string? OrderDate { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public string? InvoiceDate { get; set; }

    public int InvoiceLine { get; set; }

    public string SalesItemNo { get; set; } = null!;

    public string CommodityId { get; set; } = null!;

    public int? OrderQty { get; set; }

    public int? OrderQtyDelivered { get; set; }

    public decimal? CustomerBuyingPrice { get; set; }

    public decimal? Price { get; set; }

    public int? PriceTypeId { get; set; }

    public int? PriceSrp { get; set; }

    public int? InvoiceCostOfSalesPcs { get; set; }

    public int OwnerId { get; set; }

    public string? TransmissionDate { get; set; }
}

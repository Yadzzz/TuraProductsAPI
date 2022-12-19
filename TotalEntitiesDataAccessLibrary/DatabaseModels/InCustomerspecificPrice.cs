using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class InCustomerspecificPrice
{
    public string CustomerNo { get; set; } = null!;

    public string SalesItemNo { get; set; } = null!;

    public int? CustomerSalesPart { get; set; }

    public int? CustomerGtin { get; set; }

    public int? CustomerCommodityGroupId { get; set; }

    public int? CustomerCommodityGroup { get; set; }

    public int? Quantity { get; set; }

    public decimal? BlockPrice { get; set; }

    public string? BlockCurrencyId { get; set; }

    public int? CustomerSrp { get; set; }

    public int? CustomerCurrency { get; set; }

    public int OwnerId { get; set; }

    public string? TransmissionDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class OutSalesLineOrderhistory
{
    public string InvoiceType { get; set; } = null!;

    public string CustomerNo { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public string InvoiceId { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public int InvoiceLine { get; set; }

    public string SalesItemNo { get; set; } = null!;

    public string ItemGroupId { get; set; } = null!;

    public decimal OrderQuantity { get; set; }

    public decimal DeliveryQuantity { get; set; }

    public decimal CustomerBuyingPrice { get; set; }

    public decimal StandardBuyingPrice { get; set; }

    public string AssociationId { get; set; } = null!;

    public string SuggestedRetailPrice { get; set; } = null!;

    public string CostOfSales { get; set; } = null!;
}

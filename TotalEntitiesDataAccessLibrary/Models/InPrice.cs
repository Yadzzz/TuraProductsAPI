using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class InPrice
{
    public string SalesItemNo { get; set; } = null!;

    public int PriceTypeId { get; set; }

    public decimal? Price { get; set; }

    public string? InvoiceCurrencyId { get; set; }

    public int? Quantity { get; set; }

    public DateTime PriceStartDate { get; set; }

    public DateTime PriceEndDate { get; set; }

    public int OwnerId { get; set; }

    public string? TransmissionDate { get; set; }
}

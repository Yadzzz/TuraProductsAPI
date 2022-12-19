using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class SalesInvoiceHeader
{
    public string No { get; set; } = null!;

    public string SellToCustomerNo { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public DateTime PostingDate { get; set; }

    public string OrderNo { get; set; } = null!;

    public decimal? Amount { get; set; }

    public decimal? AmountInclVat { get; set; }

    public string? YourOrderNo { get; set; }

    public string? YourReference { get; set; }

    public string? CurrencyCode { get; set; }

    public DateTime? DueDate { get; set; }

    public bool? IsOpen { get; set; }
}

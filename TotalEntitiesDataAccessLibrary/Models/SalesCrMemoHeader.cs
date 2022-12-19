using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class SalesCrMemoHeader
{
    public byte[] Timestamp { get; set; } = null!;

    public string No { get; set; } = null!;

    public string SellToCustomerNo { get; set; } = null!;

    public DateTime PostingDate { get; set; }

    public string ReturnOrderNo { get; set; } = null!;

    public decimal? Amount { get; set; }

    public decimal? AmountInclVat { get; set; }

    public string? YourOrderNo { get; set; }

    public string? YourReference { get; set; }

    public string? CurrencyCode { get; set; }

    public DateTime? DueDate { get; set; }

    public bool? IsOpen { get; set; }
}

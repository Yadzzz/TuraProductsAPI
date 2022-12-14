using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class ItemFeePrice
{
    public byte[] Timestamp { get; set; } = null!;

    public int FeeType { get; set; }

    public string FeeCode { get; set; } = null!;

    public string FeeCustomerGroup { get; set; } = null!;

    public DateTime StartingDate { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public DateTime EndingDate { get; set; }
}

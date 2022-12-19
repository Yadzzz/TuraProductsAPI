using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class SalesLineDiscount
{
    public byte[] Timestamp { get; set; } = null!;

    public int Type { get; set; }

    public string Code { get; set; } = null!;

    public int SalesType { get; set; }

    public string SalesCode { get; set; } = null!;

    public DateTime StartingDate { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal MinimumQuantity { get; set; }

    public decimal LineDiscount { get; set; }

    public DateTime EndingDate { get; set; }
}

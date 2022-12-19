using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class CustomerPrice
{
    public byte[] Timestamp { get; set; } = null!;

    public string CustomerNo { get; set; } = null!;

    public string CurrencyCode { get; set; } = null!;

    public string SalesCode { get; set; } = null!;

    public string ItemNo { get; set; } = null!;

    public decimal? CustomerPrice1 { get; set; }

    public byte AllowLineDisc { get; set; }

    public decimal? Discount { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime EndingDate { get; set; }

    public decimal? ItemFee { get; set; }

    public decimal MinimumQuantity { get; set; }

    public byte? NotDivisibleUnit { get; set; }

    public decimal? RecPrice { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateTime? ModifiedDate { get; set; }
}

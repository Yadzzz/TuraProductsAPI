using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class InFee
{
    public string SalesItemNo { get; set; } = null!;

    public int FeeTypeId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public int OwnerId { get; set; }

    public DateTime TransmissionDate { get; set; }

    public decimal? FeeValue { get; set; }
}

using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class OutCustomerspecificPrice
{
    public string SalesItemNo { get; set; } = null!;

    public decimal Amount { get; set; }

    public string CustomerNo { get; set; } = null!;

    public decimal? Price { get; set; }
}

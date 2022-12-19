using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class OutSalesstatus
{
    public string SalesItemNo { get; set; } = null!;

    public string? SalesStatusId { get; set; }

    public string SalesStatus { get; set; } = null!;
}

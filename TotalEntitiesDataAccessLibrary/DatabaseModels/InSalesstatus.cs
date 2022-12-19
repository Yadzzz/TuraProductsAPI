using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class InSalesstatus
{
    public string SalesItemNo { get; set; } = null!;

    public string? SalesStatusId { get; set; }

    public string SalesStatusDescription { get; set; } = null!;

    public int OwnerId { get; set; }

    public string? TransmissionDate { get; set; }
}

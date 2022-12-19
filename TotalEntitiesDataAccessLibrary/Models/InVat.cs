using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class InVat
{
    public string SalesItemNo { get; set; } = null!;

    public string? VatTypeId { get; set; }

    public int OwnerId { get; set; }

    public DateTime TransmissionDate { get; set; }

    public decimal VatValue { get; set; }
}

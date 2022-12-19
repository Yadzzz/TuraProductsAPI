using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class HamaItemDescription
{
    public string SalesItemNo { get; set; } = null!;

    public string? ItemDescriptionSw { get; set; }

    public string? ItemDescriptionNo { get; set; }

    public string? ItemDescriptionFi { get; set; }

    public string? ItemDescriptionDk { get; set; }

    public string? ItemDescriptionEn { get; set; }

    public string? UnspscId { get; set; }

    public string? UnspscName { get; set; }

    public string? ItemTechSw { get; set; }

    public string? ItemTechNo { get; set; }

    public string? ItemTechFi { get; set; }

    public string? ItemTechDk { get; set; }

    public string? ItemTechEn { get; set; }
}

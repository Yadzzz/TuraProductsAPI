using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class TestHamaItemDescription
{
    public string SalesItemNo { get; set; } = null!;

    public string? ItemDescriptionSw { get; set; }

    public string? ItemDescriptionNo { get; set; }

    public string? ItemDescriptionFi { get; set; }

    public string? ItemDescriptionDk { get; set; }

    public string? ItemDescriptionEn { get; set; }
}

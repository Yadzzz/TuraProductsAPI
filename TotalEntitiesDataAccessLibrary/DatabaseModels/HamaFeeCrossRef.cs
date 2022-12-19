using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class HamaFeeCrossRef
{
    public int HamaCode { get; set; }

    public string NavCode { get; set; } = null!;

    public string? CountryCode { get; set; }
}

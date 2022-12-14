using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class SalesHeader
{
    public int DocumentType { get; set; }

    public string No { get; set; } = null!;

    public DateTime OrderDate { get; set; }
}

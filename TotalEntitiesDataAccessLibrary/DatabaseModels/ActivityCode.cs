using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class ActivityCode
{
    public byte[] Timestamp { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;
}

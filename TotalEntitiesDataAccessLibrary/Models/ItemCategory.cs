using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class ItemCategory
{
    public byte[] Timestamp { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;
}

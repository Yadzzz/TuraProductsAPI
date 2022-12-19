using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class WipProductCategoryLink
{
    public int ParentEnovaId { get; set; }

    public int ChildEnovaId { get; set; }

    public bool IsDeleted { get; set; }

    public byte[] Ts { get; set; } = null!;

    public long? Tsnumber { get; set; }
}

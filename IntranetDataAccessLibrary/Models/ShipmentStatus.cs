using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class ShipmentStatus
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<ShipmentUpdate> ShipmentUpdates { get; } = new List<ShipmentUpdate>();
}

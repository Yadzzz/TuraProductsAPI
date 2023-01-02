using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class ShipmentUpdate
{
    public DateTime UpdatedAt { get; set; }

    public int Id { get; set; }

    public int? UpdatedBy { get; set; }

    public int ShipmentId { get; set; }

    public string? Note { get; set; }

    public int StatusId { get; set; }

    public virtual Shipment Shipment { get; set; } = null!;

    public virtual ShipmentStatus Status { get; set; } = null!;

    public virtual ShipmentEmployee? UpdatedByNavigation { get; set; }
}

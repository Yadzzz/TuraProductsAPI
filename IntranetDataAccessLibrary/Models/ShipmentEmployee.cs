using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class ShipmentEmployee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<Shipment> ShipmentInitatedByNavigations { get; } = new List<Shipment>();

    public virtual ICollection<Shipment> ShipmentReceivedByNavigations { get; } = new List<Shipment>();

    public virtual ICollection<ShipmentUpdate> ShipmentUpdates { get; } = new List<ShipmentUpdate>();
}

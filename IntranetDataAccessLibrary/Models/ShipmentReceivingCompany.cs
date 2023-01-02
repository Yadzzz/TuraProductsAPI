using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class ShipmentReceivingCompany
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Shipment> Shipments { get; } = new List<Shipment>();
}

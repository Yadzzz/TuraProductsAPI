using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class Shipment
{
    public int Id { get; set; }

    public DateTime ReceivedAt { get; set; }

    public int? ReceivedBy { get; set; }

    public int? ReceivingCompany { get; set; }

    public string? OrderNumbers { get; set; }

    public int? NumberOfPallets { get; set; }

    public int? NumberOfPackages { get; set; }

    public string? Placement { get; set; }

    public int? InitatedBy { get; set; }

    public string? Supplier { get; set; }

    public bool? Prioritized { get; set; }

    public virtual ShipmentEmployee? InitatedByNavigation { get; set; }

    public virtual ShipmentEmployee? ReceivedByNavigation { get; set; }

    public virtual ShipmentReceivingCompany? ReceivingCompanyNavigation { get; set; }

    public virtual ShipmentDeviation? ShipmentDeviation { get; set; }

    public virtual ICollection<ShipmentUpdate> ShipmentUpdates { get; } = new List<ShipmentUpdate>();
}

using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class HamaPurchaseorder
{
    public int PurchaseorderId { get; set; }

    public int? AccountId { get; set; }

    public int? UsersessionId { get; set; }

    public int? CurrencyId { get; set; }

    public int? Status { get; set; }

    public int? DeliveryaddressId { get; set; }

    public string? Customernumber { get; set; }

    public string? InternalNote { get; set; }

    public string? Note { get; set; }

    public string? DeliveryDate { get; set; }

    public DateTime? AusgelesenAm { get; set; }

    public decimal? TotalSum { get; set; }

    public int RecordstatusId { get; set; }

    public DateTime LastModified { get; set; }

    public string? ExternalAddressId { get; set; }

    public int? TempDeliveryaddressId { get; set; }

    public int Ordertype { get; set; }

    public string? ExternalId { get; set; }
}

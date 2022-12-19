using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class WipWebOrder
{
    public string OrderNumber { get; set; } = null!;

    public string? CustomerNumber { get; set; }

    public DateTime? OrderedAt { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? CoAddress { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public int? TotalQuantity { get; set; }

    public string? CurrencyIsocode { get; set; }

    public decimal? TotalPrice { get; set; }

    public byte[]? Ts { get; set; }

    public long? Tsnumber { get; set; }

    public bool? IsExported { get; set; }

    public bool? IsImported { get; set; }

    public string? OrderReference { get; set; }

    public string? Name2 { get; set; }

    public string? Phone { get; set; }

    public DateTime? PreferredDeliveryDate { get; set; }

    public bool? JointDelivery { get; set; }

    public string? AddressCode { get; set; }

    public string? Email { get; set; }

    public int? ShippingType { get; set; }

    public virtual ICollection<WipWebOrderRow> WipWebOrderRows { get; } = new List<WipWebOrderRow>();
}

using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class ShipToAddress
{
    public byte[] Timestamp { get; set; } = null!;

    public string CustomerNo { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Name2 { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string TelexNo { get; set; } = null!;

    public string CountryRegionCode { get; set; } = null!;

    public DateTime LastDateModified { get; set; }

    public string LocationCode { get; set; } = null!;

    public string FaxNo { get; set; } = null!;

    public string PostCode { get; set; } = null!;

    public string County { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string HomePage { get; set; } = null!;
}

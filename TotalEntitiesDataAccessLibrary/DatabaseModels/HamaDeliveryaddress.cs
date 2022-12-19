using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class HamaDeliveryaddress
{
    public int PurchaseorderId { get; set; }

    public int CustomerId { get; set; }

    public int? TempDeliveryaddressId { get; set; }

    public string? Name1 { get; set; }

    public string? Name2 { get; set; }

    public string? Street { get; set; }

    public string? AdditonToCustomeraddress { get; set; }

    public string? Zipcode { get; set; }

    public string? City { get; set; }

    public int CountryId { get; set; }

    public string? Country { get; set; }

    public int RecordstatusId { get; set; }

    public string? StreetNumber { get; set; }

    public DateTime LastModified { get; set; }

    public int Sortvalue { get; set; }

    public string? MobilePhoneNo { get; set; }
}

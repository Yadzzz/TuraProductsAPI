using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class InCustomeraddress
{
    public int? CustomerAdressId { get; set; }

    public string CustomerNo { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public int CustomerAdressTypeId { get; set; }

    public string CustomerStreet { get; set; } = null!;

    public string AdditionToAdress { get; set; } = null!;

    public string CustomerZipcode { get; set; } = null!;

    public string CustomerCity { get; set; } = null!;

    public string CustomerCountry { get; set; } = null!;

    public int? Default { get; set; }

    public int OwnerId { get; set; }

    public string? TransmissionDate { get; set; }

    public string CustomerName1 { get; set; } = null!;

    public string CustomerName2 { get; set; } = null!;

    public int CustomerAddressDefault { get; set; }
}

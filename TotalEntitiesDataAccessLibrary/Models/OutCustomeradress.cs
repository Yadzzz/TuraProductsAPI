using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class OutCustomeradress
{
    public string AddressId { get; set; } = null!;

    public string Customernumber { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public int AddresstypeId { get; set; }

    public string Street { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int Default { get; set; }

    public int Importstatus { get; set; }

    public DateTime InsertDate { get; set; }
}

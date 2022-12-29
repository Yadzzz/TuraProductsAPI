using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class SpecialCustomer
{
    public int Id { get; set; }

    public string CustomerNumber { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public string? Instructions { get; set; }

    public string? ResponsibleSalesPerson { get; set; }

    public string? SalesPersonPhone { get; set; }
}

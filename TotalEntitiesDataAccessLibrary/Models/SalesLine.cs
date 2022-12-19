using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class SalesLine
{
    public int DocumentType { get; set; }

    public string DocumentNo { get; set; } = null!;

    public int LineNo { get; set; }

    public string SellToCustomerNo { get; set; } = null!;

    public string No { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal OutstandingQuantity { get; set; }

    public decimal UnitPrice { get; set; }
}

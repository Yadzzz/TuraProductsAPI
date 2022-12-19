using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class OutCustomer
{
    public string Customernumber { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public string Gln { get; set; } = null!;

    public string Name1 { get; set; } = null!;

    public string Name2 { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Web { get; set; } = null!;

    public string CreditratingId { get; set; } = null!;

    public string CreditcheckId { get; set; } = null!;

    public decimal Creditlimit { get; set; }

    public string Active { get; set; } = null!;

    public int Importstatus { get; set; }

    public DateTime InsertDate { get; set; }
}

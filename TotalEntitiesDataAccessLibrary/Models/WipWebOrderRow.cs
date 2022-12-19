using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class WipWebOrderRow
{
    public int RowId { get; set; }

    public string? OrderNumber { get; set; }

    public double? Quantity { get; set; }

    public string? CurrencyIsocode { get; set; }

    public decimal? PiecePrice { get; set; }

    public decimal? RowPrice { get; set; }

    public byte[]? Ts { get; set; }

    public long? Tsnumber { get; set; }

    public string? ProductNumber { get; set; }

    public virtual WipWebOrder? OrderNumberNavigation { get; set; }
}

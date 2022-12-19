using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class OutStockdatum
{
    public string SalesItemNo { get; set; } = null!;

    public decimal StockAvailable { get; set; }

    public int? StockOther { get; set; }

    public int? StockPricePcs { get; set; }

    public int? StockPricePcsCurr { get; set; }

    public int? Forecast3months { get; set; }

    public int? Forecast6months { get; set; }

    public int? ForecastTotal { get; set; }

    public int? Backlogs { get; set; }

    public int? Reservations { get; set; }

    public decimal? OpenSalesOrderQty { get; set; }

    public int? OpenSalesOrderAmount { get; set; }

    public decimal? OpenPurchaseOrderQty { get; set; }

    public int? OpenPurchaseOrderNo { get; set; }

    public int? FirstEntryDate { get; set; }

    public int? FirstEntryQty { get; set; }

    public int? LastEntryDate { get; set; }

    public int? LastEntryQty { get; set; }
}

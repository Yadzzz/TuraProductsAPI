using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class InStockdatum
{
    public string SalesItemNo { get; set; } = null!;

    public int? StockAvailableQty { get; set; }

    public int? StockQsQty { get; set; }

    public int? StockLocation { get; set; }

    public int? StockWarehouse { get; set; }

    public int? StockReserveStock { get; set; }

    public int? PriceStockCost { get; set; }

    public int? PriceStockCostCurrencyId { get; set; }

    public int? Forecast3months { get; set; }

    public int? Forecast6months { get; set; }

    public int? ForecastTotal { get; set; }

    public int? OrderQtyBackorder { get; set; }

    public int? ProductionQty { get; set; }

    public int? ProductionFinishingDate { get; set; }

    public int? ReservationsTotal { get; set; }

    public int? OpenSalesOrderQty { get; set; }

    public int? OpenSalesOrders { get; set; }

    public int? OpenPurchaseOrderQty { get; set; }

    public int? OpenPurchaseOrders { get; set; }

    public int? FirstEntryDate { get; set; }

    public int? FirstEntryQty { get; set; }

    public int? LastEntryDate { get; set; }

    public int? LastEntryQty { get; set; }

    public int? EstimatedReceiptDate { get; set; }

    public int? ConfirmedReceiptDate { get; set; }

    public int OwnerId { get; set; }

    public string? TransmissionDate { get; set; }
}

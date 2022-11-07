using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavReservationEntry
    {
        public byte[] Timestamp { get; set; } = null!;
        public int EntryNo { get; set; }
        public byte Positive { get; set; }
        public string ItemNo { get; set; } = null!;
        public string LocationCode { get; set; } = null!;
        public decimal QuantityBase { get; set; }
        public int ReservationStatus { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public int TransferredFromEntryNo { get; set; }
        public int SourceType { get; set; }
        public int SourceSubtype { get; set; }
        public string SourceId { get; set; } = null!;
        public string SourceBatchName { get; set; } = null!;
        public int SourceProdOrderLine { get; set; }
        public int SourceRefNo { get; set; }
        public int ItemLedgerEntryNo { get; set; }
        public DateTime ExpectedReceiptDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string SerialNo { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string ChangedBy { get; set; } = null!;
        public decimal QtyPerUnitOfMeasure { get; set; }
        public decimal Quantity { get; set; }
        public int Binding { get; set; }
        public byte SuppressedActionMsg { get; set; }
        public int PlanningFlexibility { get; set; }
        public int ApplToItemEntry { get; set; }
        public DateTime WarrantyDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal QtyToHandleBase { get; set; }
        public decimal QtyToInvoiceBase { get; set; }
        public decimal QuantityInvoicedBase { get; set; }
        public string NewSerialNo { get; set; } = null!;
        public string NewLotNo { get; set; } = null!;
        public byte DisallowCancellation { get; set; }
        public string LotNo { get; set; } = null!;
        public string VariantCode { get; set; } = null!;
        public int ApplFromItemEntry { get; set; }
        public byte Correction { get; set; }
        public DateTime NewExpirationDate { get; set; }
        public int ItemTracking { get; set; }
    }
}

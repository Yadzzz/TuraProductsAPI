using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavItemLedgerEntry
    {
        public byte[] Timestamp { get; set; } = null!;
        public int EntryNo { get; set; }
        public string ItemNo { get; set; } = null!;
        public DateTime PostingDate { get; set; }
        public int EntryType { get; set; }
        public string SourceNo { get; set; } = null!;
        public string DocumentNo { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string LocationCode { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public decimal InvoicedQuantity { get; set; }
        public int AppliesToEntry { get; set; }
        public byte Open { get; set; }
        public string GlobalDimension1Code { get; set; } = null!;
        public string GlobalDimension2Code { get; set; } = null!;
        public byte Positive { get; set; }
        public int SourceType { get; set; }
        public byte DropShipment { get; set; }
        public string TransactionType { get; set; } = null!;
        public string TransportMethod { get; set; } = null!;
        public string CountryRegionCode { get; set; } = null!;
        public string EntryExitPoint { get; set; } = null!;
        public DateTime DocumentDate { get; set; }
        public string ExternalDocumentNo { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string TransactionSpecification { get; set; } = null!;
        public string NoSeries { get; set; } = null!;
        public int DocumentType { get; set; }
        public int DocumentLineNo { get; set; }
        public int OrderType { get; set; }
        public string OrderNo { get; set; } = null!;
        public int OrderLineNo { get; set; }
        public int DimensionSetId { get; set; }
        public byte AssembleToOrder { get; set; }
        public string JobNo { get; set; } = null!;
        public string JobTaskNo { get; set; } = null!;
        public byte JobPurchase { get; set; }
        public string VariantCode { get; set; } = null!;
        public decimal QtyPerUnitOfMeasure { get; set; }
        public string UnitOfMeasureCode { get; set; } = null!;
        public byte DerivedFromBlanketOrder { get; set; }
        public string CrossReferenceNo { get; set; } = null!;
        public string OriginallyOrderedNo { get; set; } = null!;
        public string OriginallyOrderedVarCode { get; set; } = null!;
        public byte OutOfStockSubstitution { get; set; }
        public string ItemCategoryCode { get; set; } = null!;
        public byte Nonstock { get; set; }
        public string PurchasingCode { get; set; } = null!;
        public string ProductGroupCode { get; set; } = null!;
        public byte CompletelyInvoiced { get; set; }
        public DateTime LastInvoiceDate { get; set; }
        public byte AppliedEntryToAdjust { get; set; }
        public byte Correction { get; set; }
        public decimal ShippedQtyNotReturned { get; set; }
        public int ProdOrderCompLineNo { get; set; }
        public string SerialNo { get; set; } = null!;
        public string LotNo { get; set; } = null!;
        public DateTime WarrantyDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ItemTracking { get; set; }
        public string ReturnReasonCode { get; set; } = null!;
        public string CertificateCode { get; set; } = null!;
        public string CertificateNo { get; set; } = null!;
        public byte EuGoods { get; set; }
        public string BenefitCode { get; set; } = null!;
        public decimal FreightDirectUnitCost { get; set; }
    }
}

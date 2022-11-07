using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavSalesLine
    {
        public byte[] Timestamp { get; set; } = null!;
        public int DocumentType { get; set; }
        public string DocumentNo { get; set; } = null!;
        public int LineNo { get; set; }
        public string SellToCustomerNo { get; set; } = null!;
        public int Type { get; set; }
        public string No { get; set; } = null!;
        public string LocationCode { get; set; } = null!;
        public string PostingGroup { get; set; } = null!;
        public DateTime ShipmentDate { get; set; }
        public string Description { get; set; } = null!;
        public string Description2 { get; set; } = null!;
        public string UnitOfMeasure { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal OutstandingQuantity { get; set; }
        public decimal QtyToInvoice { get; set; }
        public decimal QtyToShip { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCostLcy { get; set; }
        public decimal Vat { get; set; }
        public decimal LineDiscount { get; set; }
        public decimal LineDiscountAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountIncludingVat { get; set; }
        public byte AllowInvoiceDisc { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal UnitsPerParcel { get; set; }
        public decimal UnitVolume { get; set; }
        public int ApplToItemEntry { get; set; }
        public string ShortcutDimension1Code { get; set; } = null!;
        public string ShortcutDimension2Code { get; set; } = null!;
        public string CustomerPriceGroup { get; set; } = null!;
        public string JobNo { get; set; } = null!;
        public string WorkTypeCode { get; set; } = null!;
        public byte RecalculateInvoiceDisc { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal QtyShippedNotInvoiced { get; set; }
        public decimal ShippedNotInvoiced { get; set; }
        public decimal QuantityShipped { get; set; }
        public decimal QuantityInvoiced { get; set; }
        public string ShipmentNo { get; set; } = null!;
        public int ShipmentLineNo { get; set; }
        public decimal Profit { get; set; }
        public string BillToCustomerNo { get; set; } = null!;
        public decimal InvDiscountAmount { get; set; }
        public string PurchaseOrderNo { get; set; } = null!;
        public int PurchOrderLineNo { get; set; }
        public byte DropShipment { get; set; }
        public string GenBusPostingGroup { get; set; } = null!;
        public string GenProdPostingGroup { get; set; } = null!;
        public int VatCalculationType { get; set; }
        public string TransactionType { get; set; } = null!;
        public string TransportMethod { get; set; } = null!;
        public int AttachedToLineNo { get; set; }
        public string ExitPoint { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string TransactionSpecification { get; set; } = null!;
        public string TaxAreaCode { get; set; } = null!;
        public byte TaxLiable { get; set; }
        public string TaxGroupCode { get; set; } = null!;
        public string VatClauseCode { get; set; } = null!;
        public string VatBusPostingGroup { get; set; } = null!;
        public string VatProdPostingGroup { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public decimal OutstandingAmountLcy { get; set; }
        public decimal ShippedNotInvoicedLcy { get; set; }
        public int Reserve { get; set; }
        public string BlanketOrderNo { get; set; } = null!;
        public int BlanketOrderLineNo { get; set; }
        public decimal VatBaseAmount { get; set; }
        public decimal UnitCost { get; set; }
        public byte SystemCreatedEntry { get; set; }
        public decimal LineAmount { get; set; }
        public decimal VatDifference { get; set; }
        public decimal InvDiscAmountToInvoice { get; set; }
        public string VatIdentifier { get; set; } = null!;
        public int IcPartnerRefType { get; set; }
        public string IcPartnerReference { get; set; } = null!;
        public decimal Prepayment { get; set; }
        public decimal PrepmtLineAmount { get; set; }
        public decimal PrepmtAmtInv { get; set; }
        public decimal PrepmtAmtInclVat { get; set; }
        public decimal PrepaymentAmount { get; set; }
        public decimal PrepmtVatBaseAmt { get; set; }
        public decimal PrepaymentVat { get; set; }
        public int PrepmtVatCalcType { get; set; }
        public string PrepaymentVatIdentifier { get; set; } = null!;
        public string PrepaymentTaxAreaCode { get; set; } = null!;
        public byte PrepaymentTaxLiable { get; set; }
        public string PrepaymentTaxGroupCode { get; set; } = null!;
        public decimal PrepmtAmtToDeduct { get; set; }
        public decimal PrepmtAmtDeducted { get; set; }
        public byte PrepaymentLine { get; set; }
        public decimal PrepmtAmountInvInclVat { get; set; }
        public decimal PrepmtAmountInvLcy { get; set; }
        public string IcPartnerCode { get; set; } = null!;
        public decimal PrepmtVatAmountInvLcy { get; set; }
        public decimal PrepaymentVatDifference { get; set; }
        public decimal PrepmtVatDiffToDeduct { get; set; }
        public decimal PrepmtVatDiffDeducted { get; set; }
        public int DimensionSetId { get; set; }
        public decimal QtyToAssembleToOrder { get; set; }
        public decimal QtyToAsmToOrderBase { get; set; }
        public string JobTaskNo { get; set; } = null!;
        public int JobContractEntryNo { get; set; }
        public string VariantCode { get; set; } = null!;
        public string BinCode { get; set; } = null!;
        public decimal QtyPerUnitOfMeasure { get; set; }
        public byte Planned { get; set; }
        public string UnitOfMeasureCode { get; set; } = null!;
        public decimal QuantityBase { get; set; }
        public decimal OutstandingQtyBase { get; set; }
        public decimal QtyToInvoiceBase { get; set; }
        public decimal QtyToShipBase { get; set; }
        public decimal QtyShippedNotInvdBase { get; set; }
        public decimal QtyShippedBase { get; set; }
        public decimal QtyInvoicedBase { get; set; }
        public DateTime FaPostingDate { get; set; }
        public string DepreciationBookCode { get; set; } = null!;
        public byte DeprUntilFaPostingDate { get; set; }
        public string DuplicateInDepreciationBook { get; set; } = null!;
        public byte UseDuplicationList { get; set; }
        public string ResponsibilityCenter { get; set; } = null!;
        public byte OutOfStockSubstitution { get; set; }
        public string OriginallyOrderedNo { get; set; } = null!;
        public string OriginallyOrderedVarCode { get; set; } = null!;
        public string CrossReferenceNo { get; set; } = null!;
        public string UnitOfMeasureCrossRef { get; set; } = null!;
        public int CrossReferenceType { get; set; }
        public string CrossReferenceTypeNo { get; set; } = null!;
        public string ItemCategoryCode { get; set; } = null!;
        public byte Nonstock { get; set; }
        public string PurchasingCode { get; set; } = null!;
        public string ProductGroupCode { get; set; } = null!;
        public byte SpecialOrder { get; set; }
        public string SpecialOrderPurchaseNo { get; set; } = null!;
        public int SpecialOrderPurchLineNo { get; set; }
        public byte CompletelyShipped { get; set; }
        public DateTime RequestedDeliveryDate { get; set; }
        public DateTime PromisedDeliveryDate { get; set; }
        public string ShippingTime { get; set; } = null!;
        public string OutboundWhseHandlingTime { get; set; } = null!;
        public DateTime PlannedDeliveryDate { get; set; }
        public DateTime PlannedShipmentDate { get; set; }
        public string ShippingAgentCode { get; set; } = null!;
        public string ShippingAgentServiceCode { get; set; } = null!;
        public byte AllowItemChargeAssignment { get; set; }
        public decimal ReturnQtyToReceive { get; set; }
        public decimal ReturnQtyToReceiveBase { get; set; }
        public decimal ReturnQtyRcdNotInvd { get; set; }
        public decimal RetQtyRcdNotInvdBase { get; set; }
        public decimal ReturnRcdNotInvd { get; set; }
        public decimal ReturnRcdNotInvdLcy { get; set; }
        public decimal ReturnQtyReceived { get; set; }
        public decimal ReturnQtyReceivedBase { get; set; }
        public int ApplFromItemEntry { get; set; }
        public string BomItemNo { get; set; } = null!;
        public string ReturnReceiptNo { get; set; } = null!;
        public int ReturnReceiptLineNo { get; set; }
        public string ReturnReasonCode { get; set; } = null!;
        public byte AllowLineDisc { get; set; }
        public string CustomerDiscGroup { get; set; } = null!;
        public string AutoAccGroup { get; set; } = null!;
        public DateTime CustomerDeliveryDate { get; set; }
        public string ExternalOrderNo { get; set; } = null!;
        public string ExternalOrderLineNo { get; set; } = null!;
        public string Ordertype { get; set; } = null!;
        public string YourOrderNo { get; set; } = null!;
        public byte FeeLine { get; set; }
        public int FeeItemLineNo { get; set; }
        public int ExternalLineNo { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal OutstandingQty { get; set; }
        public byte WhseShipLineCreated { get; set; }
        public string ActivityStatus { get; set; } = null!;
        public decimal Ediprice { get; set; }
        public decimal Ediqty { get; set; }
        public int EdilineNo { get; set; }
        public string EdieanNo { get; set; } = null!;
        public string CertificateCode { get; set; } = null!;
        public string CertificateNo { get; set; } = null!;
        public byte EuGoods { get; set; }
        public string BenefitCode { get; set; } = null!;
        public string SalespersonCode { get; set; } = null!;
        public int PebChargeType { get; set; }
        public int PebTextConnectedToLineNo { get; set; }
        public byte PebConnectedToItemLine { get; set; }
        public string TaxCategory { get; set; } = null!;
        public decimal ShippedNotInvLcyNoVat { get; set; }
        public int LineDiscountCalculation { get; set; }
        public string DeferralCode { get; set; } = null!;
        public DateTime ReturnsDeferralStartDate { get; set; }
        public int Subtype { get; set; }
        public string PriceDescription { get; set; } = null!;
    }
}

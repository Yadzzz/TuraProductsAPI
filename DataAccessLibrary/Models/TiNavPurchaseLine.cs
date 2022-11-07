using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavPurchaseLine
    {
        public byte[] Timestamp { get; set; } = null!;
        public int DocumentType { get; set; }
        public string DocumentNo { get; set; } = null!;
        public int LineNo { get; set; }
        public string BuyFromVendorNo { get; set; } = null!;
        public int Type { get; set; }
        public string No { get; set; } = null!;
        public string LocationCode { get; set; } = null!;
        public string PostingGroup { get; set; } = null!;
        public DateTime ExpectedReceiptDate { get; set; }
        public string Description { get; set; } = null!;
        public string Description2 { get; set; } = null!;
        public string UnitOfMeasure { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal OutstandingQuantity { get; set; }
        public decimal QtyToInvoice { get; set; }
        public decimal QtyToReceive { get; set; }
        public decimal DirectUnitCost { get; set; }
        public decimal UnitCostLcy { get; set; }
        public decimal Vat { get; set; }
        public decimal LineDiscount { get; set; }
        public decimal LineDiscountAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountIncludingVat { get; set; }
        public decimal UnitPriceLcy { get; set; }
        public byte AllowInvoiceDisc { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal UnitsPerParcel { get; set; }
        public decimal UnitVolume { get; set; }
        public int ApplToItemEntry { get; set; }
        public string ShortcutDimension1Code { get; set; } = null!;
        public string ShortcutDimension2Code { get; set; } = null!;
        public string JobNo { get; set; } = null!;
        public decimal IndirectCost { get; set; }
        public byte RecalculateInvoiceDisc { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal QtyRcdNotInvoiced { get; set; }
        public decimal AmtRcdNotInvoiced { get; set; }
        public decimal QuantityReceived { get; set; }
        public decimal QuantityInvoiced { get; set; }
        public string ReceiptNo { get; set; } = null!;
        public int ReceiptLineNo { get; set; }
        public decimal Profit { get; set; }
        public string PayToVendorNo { get; set; } = null!;
        public decimal InvDiscountAmount { get; set; }
        public string VendorItemNo { get; set; } = null!;
        public string SalesOrderNo { get; set; } = null!;
        public int SalesOrderLineNo { get; set; }
        public byte DropShipment { get; set; }
        public string GenBusPostingGroup { get; set; } = null!;
        public string GenProdPostingGroup { get; set; } = null!;
        public int VatCalculationType { get; set; }
        public string TransactionType { get; set; } = null!;
        public string TransportMethod { get; set; } = null!;
        public int AttachedToLineNo { get; set; }
        public string EntryPoint { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string TransactionSpecification { get; set; } = null!;
        public string TaxAreaCode { get; set; } = null!;
        public byte TaxLiable { get; set; }
        public string TaxGroupCode { get; set; } = null!;
        public byte UseTax { get; set; }
        public string VatBusPostingGroup { get; set; } = null!;
        public string VatProdPostingGroup { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public decimal OutstandingAmountLcy { get; set; }
        public decimal AmtRcdNotInvoicedLcy { get; set; }
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
        public decimal OutstandingAmtExVatLcy { get; set; }
        public decimal ARcdNotInvExVatLcy { get; set; }
        public int DimensionSetId { get; set; }
        public string JobTaskNo { get; set; } = null!;
        public int JobLineType { get; set; }
        public decimal JobUnitPrice { get; set; }
        public decimal JobTotalPrice { get; set; }
        public decimal JobLineAmount { get; set; }
        public decimal JobLineDiscountAmount { get; set; }
        public decimal JobLineDiscount { get; set; }
        public decimal JobUnitPriceLcy { get; set; }
        public decimal JobTotalPriceLcy { get; set; }
        public decimal JobLineAmountLcy { get; set; }
        public decimal JobLineDiscAmountLcy { get; set; }
        public decimal JobCurrencyFactor { get; set; }
        public string JobCurrencyCode { get; set; } = null!;
        public int JobPlanningLineNo { get; set; }
        public decimal JobRemainingQty { get; set; }
        public decimal JobRemainingQtyBase { get; set; }
        public string DeferralCode { get; set; } = null!;
        public DateTime ReturnsDeferralStartDate { get; set; }
        public string ProdOrderNo { get; set; } = null!;
        public string VariantCode { get; set; } = null!;
        public string BinCode { get; set; } = null!;
        public decimal QtyPerUnitOfMeasure { get; set; }
        public string UnitOfMeasureCode { get; set; } = null!;
        public decimal QuantityBase { get; set; }
        public decimal OutstandingQtyBase { get; set; }
        public decimal QtyToInvoiceBase { get; set; }
        public decimal QtyToReceiveBase { get; set; }
        public decimal QtyRcdNotInvoicedBase { get; set; }
        public decimal QtyReceivedBase { get; set; }
        public decimal QtyInvoicedBase { get; set; }
        public DateTime FaPostingDate { get; set; }
        public int FaPostingType { get; set; }
        public string DepreciationBookCode { get; set; } = null!;
        public decimal SalvageValue { get; set; }
        public byte DeprUntilFaPostingDate { get; set; }
        public byte DeprAcquisitionCost { get; set; }
        public string MaintenanceCode { get; set; } = null!;
        public string InsuranceNo { get; set; } = null!;
        public string BudgetedFaNo { get; set; } = null!;
        public string DuplicateInDepreciationBook { get; set; } = null!;
        public byte UseDuplicationList { get; set; }
        public string ResponsibilityCenter { get; set; } = null!;
        public string CrossReferenceNo { get; set; } = null!;
        public string UnitOfMeasureCrossRef { get; set; } = null!;
        public int CrossReferenceType { get; set; }
        public string CrossReferenceTypeNo { get; set; } = null!;
        public string ItemCategoryCode { get; set; } = null!;
        public byte Nonstock { get; set; }
        public string PurchasingCode { get; set; } = null!;
        public string ProductGroupCode { get; set; } = null!;
        public byte SpecialOrder { get; set; }
        public string SpecialOrderSalesNo { get; set; } = null!;
        public int SpecialOrderSalesLineNo { get; set; }
        public byte CompletelyReceived { get; set; }
        public DateTime RequestedReceiptDate { get; set; }
        public DateTime PromisedReceiptDate { get; set; }
        public string LeadTimeCalculation { get; set; } = null!;
        public string InboundWhseHandlingTime { get; set; } = null!;
        public DateTime PlannedReceiptDate { get; set; }
        public DateTime OrderDate { get; set; }
        public byte AllowItemChargeAssignment { get; set; }
        public decimal ReturnQtyToShip { get; set; }
        public decimal ReturnQtyToShipBase { get; set; }
        public decimal ReturnQtyShippedNotInvd { get; set; }
        public decimal RetQtyShpdNotInvdBase { get; set; }
        public decimal ReturnShpdNotInvd { get; set; }
        public decimal ReturnShpdNotInvdLcy { get; set; }
        public decimal ReturnQtyShipped { get; set; }
        public decimal ReturnQtyShippedBase { get; set; }
        public string ReturnShipmentNo { get; set; } = null!;
        public int ReturnShipmentLineNo { get; set; }
        public string ReturnReasonCode { get; set; } = null!;
        public int Subtype { get; set; }
        public string AutoAccGroup { get; set; } = null!;
        public int ConfirmationStatus { get; set; }
        public int SoloLineNo { get; set; }
        public string NoteOfGoods { get; set; } = null!;
        public byte ExportedToAstro { get; set; }
        public byte Updated { get; set; }
        public string CertificateCode { get; set; } = null!;
        public string CertificateNo { get; set; } = null!;
        public byte EuGoods { get; set; }
        public string BenefitCode { get; set; } = null!;
        public decimal FreightDirectUnitCost { get; set; }
        public int PebChargeType { get; set; }
        public string RoutingNo { get; set; } = null!;
        public string OperationNo { get; set; } = null!;
        public string WorkCenterNo { get; set; } = null!;
        public byte Finished { get; set; }
        public int ProdOrderLineNo { get; set; }
        public decimal OverheadRate { get; set; }
        public byte MpsOrder { get; set; }
        public int PlanningFlexibility { get; set; }
        public string SafetyLeadTime { get; set; } = null!;
        public int RoutingReferenceNo { get; set; }
    }
}

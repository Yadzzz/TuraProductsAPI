using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavCustomer
    {
        public byte[] Timestamp { get; set; } = null!;
        public string No { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string SearchName { get; set; } = null!;
        public string Name2 { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Address2 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string PhoneNo { get; set; } = null!;
        public string TelexNo { get; set; } = null!;
        public string OurAccountNo { get; set; } = null!;
        public string TerritoryCode { get; set; } = null!;
        public string GlobalDimension1Code { get; set; } = null!;
        public string GlobalDimension2Code { get; set; } = null!;
        public string ChainName { get; set; } = null!;
        public decimal BudgetedAmount { get; set; }
        public decimal CreditLimitLcy { get; set; }
        public string CustomerPostingGroup { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public string CustomerPriceGroup { get; set; } = null!;
        public string LanguageCode { get; set; } = null!;
        public int StatisticsGroup { get; set; }
        public string PaymentTermsCode { get; set; } = null!;
        public string FinChargeTermsCode { get; set; } = null!;
        public string SalespersonCode { get; set; } = null!;
        public string ShipmentMethodCode { get; set; } = null!;
        public string ShippingAgentCode { get; set; } = null!;
        public string PlaceOfExport { get; set; } = null!;
        public string InvoiceDiscCode { get; set; } = null!;
        public string CustomerDiscGroup { get; set; } = null!;
        public string CountryRegionCode { get; set; } = null!;
        public string CollectionMethod { get; set; } = null!;
        public decimal Amount { get; set; }
        public int Blocked { get; set; }
        public int InvoiceCopies { get; set; }
        public int LastStatementNo { get; set; }
        public byte PrintStatements { get; set; }
        public string BillToCustomerNo { get; set; } = null!;
        public int Priority { get; set; }
        public string PaymentMethodCode { get; set; } = null!;
        public DateTime LastDateModified { get; set; }
        public int ApplicationMethod { get; set; }
        public byte PricesIncludingVat { get; set; }
        public string LocationCode { get; set; } = null!;
        public string FaxNo { get; set; } = null!;
        public string TelexAnswerBack { get; set; } = null!;
        public string VatRegistrationNo { get; set; } = null!;
        public byte CombineShipments { get; set; }
        public string GenBusPostingGroup { get; set; } = null!;
        public byte[]? Picture { get; set; }
        public string PostCode { get; set; } = null!;
        public string County { get; set; } = null!;
        public string EMail { get; set; } = null!;
        public string HomePage { get; set; } = null!;
        public string ReminderTermsCode { get; set; } = null!;
        public string NoSeries { get; set; } = null!;
        public string TaxAreaCode { get; set; } = null!;
        public byte TaxLiable { get; set; }
        public string VatBusPostingGroup { get; set; } = null!;
        public int Reserve { get; set; }
        public byte BlockPaymentTolerance { get; set; }
        public string IcPartnerCode { get; set; } = null!;
        public decimal Prepayment { get; set; }
        public int PartnerType { get; set; }
        public string PreferredBankAccountCode { get; set; } = null!;
        public string CashFlowPaymentTermsCode { get; set; } = null!;
        public string PrimaryContactNo { get; set; } = null!;
        public string ResponsibilityCenter { get; set; } = null!;
        public int ShippingAdvice { get; set; }
        public string ShippingTime { get; set; } = null!;
        public string ShippingAgentServiceCode { get; set; } = null!;
        public string ServiceZoneCode { get; set; } = null!;
        public byte AllowLineDisc { get; set; }
        public string BaseCalendarCode { get; set; } = null!;
        public int CopySellToAddrToQteFrom { get; set; }
        public byte WebShop { get; set; }
        public byte LesWire { get; set; }
        public byte IgnoreInvoiceRounding { get; set; }
        public DateTime LastDateTimeModified { get; set; }
        public string OrderFreightCode { get; set; } = null!;
        public string InvoiceEMail { get; set; } = null!;
        public int DelayedPayments { get; set; }
        public string ThresholdPaymentDelayDays { get; set; } = null!;
        public string Ordertype { get; set; } = null!;
        public byte NoSummationPick { get; set; }
        public int InvoiceType { get; set; }
        public string Ob10Elkjöp { get; set; } = null!;
        public string Ob10Tura { get; set; } = null!;
        public string Choice { get; set; } = null!;
        public string FeeCustomerGroupCode { get; set; } = null!;
        public byte FeeZeroPrice { get; set; }
        public int PricelistInterval { get; set; }
        public string FilterItemGroup { get; set; } = null!;
        public byte NoPartlyDelivery { get; set; }
        public string Eancode { get; set; } = null!;
        public string PebShipToCode { get; set; } = null!;
        public int PebAutoGiroType { get; set; }
        public string PebBankGiroNo { get; set; } = null!;
        public int PebApprovalStatus { get; set; }
        public string PebPlusGiroNo { get; set; } = null!;
        public string PebRegistrationNo { get; set; } = null!;
        public string PebDocumentCode { get; set; } = null!;
        public byte AshTaxOnChemicals { get; set; }
        public byte FeeInclInPrice { get; set; }
        public string WebshopAdminName { get; set; } = null!;
        public string WebshopAdminEmail { get; set; } = null!;
        public string WebshopAdminPhone { get; set; } = null!;
        public string DocumentSendingProfile { get; set; } = null!;
        public DateTime LastModifiedDateTime { get; set; }
        public string Gln { get; set; } = null!;
        public Guid Image { get; set; }
        public int ContactType { get; set; }
        public byte ValidateEuVatRegNo { get; set; }
        public Guid Id { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid PaymentTermsId { get; set; }
        public Guid ShipmentMethodId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid TaxAreaId { get; set; }
        public Guid ContactId { get; set; }
        public string ContactGraphId { get; set; } = null!;
        public byte PrivacyBlocked { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavVendor
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
        public decimal BudgetedAmount { get; set; }
        public string VendorPostingGroup { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public string LanguageCode { get; set; } = null!;
        public int StatisticsGroup { get; set; }
        public string PaymentTermsCode { get; set; } = null!;
        public string FinChargeTermsCode { get; set; } = null!;
        public string PurchaserCode { get; set; } = null!;
        public string ShipmentMethodCode { get; set; } = null!;
        public string ShippingAgentCode { get; set; } = null!;
        public string InvoiceDiscCode { get; set; } = null!;
        public string CountryRegionCode { get; set; } = null!;
        public int Blocked { get; set; }
        public string PayToVendorNo { get; set; } = null!;
        public int Priority { get; set; }
        public string PaymentMethodCode { get; set; } = null!;
        public DateTime LastDateModified { get; set; }
        public int ApplicationMethod { get; set; }
        public byte PricesIncludingVat { get; set; }
        public string FaxNo { get; set; } = null!;
        public string TelexAnswerBack { get; set; } = null!;
        public string VatRegistrationNo { get; set; } = null!;
        public string GenBusPostingGroup { get; set; } = null!;
        public byte[]? Picture { get; set; }
        public string PostCode { get; set; } = null!;
        public string County { get; set; } = null!;
        public string EMail { get; set; } = null!;
        public string HomePage { get; set; } = null!;
        public string NoSeries { get; set; } = null!;
        public string TaxAreaCode { get; set; } = null!;
        public byte TaxLiable { get; set; }
        public string VatBusPostingGroup { get; set; } = null!;
        public byte BlockPaymentTolerance { get; set; }
        public string IcPartnerCode { get; set; } = null!;
        public decimal Prepayment { get; set; }
        public string PrimaryContactNo { get; set; } = null!;
        public string ResponsibilityCenter { get; set; } = null!;
        public string LocationCode { get; set; } = null!;
        public string LeadTimeCalculation { get; set; } = null!;
        public string BaseCalendarCode { get; set; } = null!;
        public string PurchaseMethodCode { get; set; } = null!;
        public byte DoNotExportToSolo { get; set; }
        public string PhysicalAddress { get; set; } = null!;
        public int PartnerType { get; set; }
        public string CreditorNo { get; set; } = null!;
        public string PreferredBankAccountCode { get; set; } = null!;
        public string CashFlowPaymentTermsCode { get; set; } = null!;
        public byte PebNoContOfExtDocNo { get; set; }
        public string PebExternalDocumentNo { get; set; } = null!;
        public string PebRegistrationNo { get; set; } = null!;
        public string PebDocumentCode { get; set; } = null!;
        public string NameExternal { get; set; } = null!;
        public DateTime LastModifiedDateTime { get; set; }
        public string Gln { get; set; } = null!;
        public Guid Image { get; set; }
        public string DocumentSendingProfile { get; set; } = null!;
        public byte ValidateEuVatRegNo { get; set; }
        public Guid Id { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid PaymentTermsId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public byte PrivacyBlocked { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavVatPostingSetup
    {
        public byte[] Timestamp { get; set; } = null!;
        public string VatBusPostingGroup { get; set; } = null!;
        public string VatProdPostingGroup { get; set; } = null!;
        public int VatCalculationType { get; set; }
        public decimal Vat { get; set; }
        public int UnrealizedVatType { get; set; }
        public byte AdjustForPaymentDiscount { get; set; }
        public string SalesVatAccount { get; set; } = null!;
        public string SalesVatUnrealAccount { get; set; } = null!;
        public string PurchaseVatAccount { get; set; } = null!;
        public string PurchVatUnrealAccount { get; set; } = null!;
        public string ReverseChrgVatAcc { get; set; } = null!;
        public string ReverseChrgVatUnrealAcc { get; set; } = null!;
        public string VatIdentifier { get; set; } = null!;
        public byte EuService { get; set; }
        public string VatClauseCode { get; set; } = null!;
        public byte CertificateOfSupplyRequired { get; set; }
        public string TaxCategory { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}

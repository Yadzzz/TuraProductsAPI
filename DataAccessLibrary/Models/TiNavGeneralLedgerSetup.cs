using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavGeneralLedgerSetup
    {
        public byte[] Timestamp { get; set; } = null!;
        public string PrimaryKey { get; set; } = null!;
        public DateTime AllowPostingFrom { get; set; }
        public DateTime AllowPostingTo { get; set; }
        public byte RegisterTime { get; set; }
        public byte PmtDiscExclVat { get; set; }
        public byte UnrealizedVat { get; set; }
        public byte AdjustForPaymentDisc { get; set; }
        public byte MarkCrMemosAsCorrections { get; set; }
        public int LocalAddressFormat { get; set; }
        public decimal InvRoundingPrecisionLcy { get; set; }
        public int InvRoundingTypeLcy { get; set; }
        public int LocalContAddrFormat { get; set; }
        public string BankAccountNos { get; set; } = null!;
        public byte SummarizeGLEntries { get; set; }
        public string AmountDecimalPlaces { get; set; } = null!;
        public string UnitAmountDecimalPlaces { get; set; } = null!;
        public string AdditionalReportingCurrency { get; set; } = null!;
        public decimal VatTolerance { get; set; }
        public byte EmuCurrency { get; set; }
        public string LcyCode { get; set; } = null!;
        public int VatExchangeRateAdjustment { get; set; }
        public decimal AmountRoundingPrecision { get; set; }
        public decimal UnitAmountRoundingPrecision { get; set; }
        public decimal ApplnRoundingPrecision { get; set; }
        public string GlobalDimension1Code { get; set; } = null!;
        public string GlobalDimension2Code { get; set; } = null!;
        public string ShortcutDimension1Code { get; set; } = null!;
        public string ShortcutDimension2Code { get; set; } = null!;
        public string ShortcutDimension3Code { get; set; } = null!;
        public string ShortcutDimension4Code { get; set; } = null!;
        public string ShortcutDimension5Code { get; set; } = null!;
        public string ShortcutDimension6Code { get; set; } = null!;
        public string ShortcutDimension7Code { get; set; } = null!;
        public string ShortcutDimension8Code { get; set; } = null!;
        public decimal MaxVatDifferenceAllowed { get; set; }
        public int VatRoundingType { get; set; }
        public int PmtDiscTolerancePosting { get; set; }
        public string PaymentDiscountGracePeriod { get; set; } = null!;
        public decimal PaymentTolerance { get; set; }
        public decimal MaxPaymentToleranceAmount { get; set; }
        public byte AdaptMainMenuToPermissions { get; set; }
        public DateTime AllowGLAccDeletionBefore { get; set; }
        public byte CheckGLAccountUsage { get; set; }
        public int PaymentTolerancePosting { get; set; }
        public byte PmtDiscToleranceWarning { get; set; }
        public byte PaymentToleranceWarning { get; set; }
        public int LastIcTransactionNo { get; set; }
        public int BillToSellToVatCalc { get; set; }
        public string AccSchedForBalanceSheet { get; set; } = null!;
        public string AccSchedForIncomeStmt { get; set; } = null!;
        public string AccSchedForCashFlowStmt { get; set; } = null!;
        public string AccSchedForRetainedEarn { get; set; } = null!;
        public byte PrintVatSpecificationInLcy { get; set; }
        public byte PrepaymentUnrealizedVat { get; set; }
        public byte UseLegacyGLEntryLocking { get; set; }
        public string PayrollTransImportFormat { get; set; } = null!;
        public string VatRegNoValidationUrl { get; set; } = null!;
        public string LocalCurrencySymbol { get; set; } = null!;
        public string LocalCurrencyDescription { get; set; } = null!;
        public int ShowAmounts { get; set; }
        public string NoGLPostingNos { get; set; } = null!;
        public string NoPostingCompany { get; set; } = null!;
        public string CurrencyDeviationAccount { get; set; } = null!;
        public string NoBalanceAccountNo { get; set; } = null!;
        public byte AutoTransferForeighnEntry { get; set; }
        public byte ActivateForeignCurrencyPost { get; set; }
        public string GeneralDocumentLanguage { get; set; } = null!;
        public byte CheckPrinterQue { get; set; }
        public byte DocumentCompanyAddress { get; set; }
        public byte DocumentFootHeadline { get; set; }
        public byte DocumentFootData { get; set; }
        public byte NoDateCheck { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.DatabaseModels;

public partial class InCustomer
{
    public string CustomerNo { get; set; } = null!;

    public int? CustomerId { get; set; }

    public string CustomerGln { get; set; } = null!;

    public string CustomerName1 { get; set; } = null!;

    public string CustomerName2 { get; set; } = null!;

    public int? CustomerCode { get; set; }

    public string CustomerPhone { get; set; } = null!;

    public string CustomerFax { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string CustomerWeb { get; set; } = null!;

    public int CustomerCreditRatingId { get; set; }

    public int? CustomerCreditRating { get; set; }

    public int? CustomerCreditCheckFlag { get; set; }

    public decimal CustomerCreditLimit { get; set; }

    public int? CustomerDebtClaim { get; set; }

    public int? CustomerFreeDeliveryMinQty { get; set; }

    public byte? CustomerActive { get; set; }

    public int SuitableBacklogsFlag { get; set; }

    public int? CustomerBank { get; set; }

    public int? CustomerBankNo { get; set; }

    public int? CustomerBankAccountNo { get; set; }

    public int? CustomerBankIban { get; set; }

    public int? CustomerBankCollectionFlag { get; set; }

    public int? CustomerCreditPeriod { get; set; }

    public int? CustomerReminder { get; set; }

    public int? CustomerCashDiscount { get; set; }

    public int? CustomerReminderFrequency { get; set; }

    public int? CustomerDefaultInterest { get; set; }

    public int? CustomerInternalCreditorId { get; set; }

    public int? CustomerInternalDiscountId { get; set; }

    public int? CustomerPaymentCorrectionId { get; set; }

    public int? CustomerAgent { get; set; }

    public int? CustomerAccountManager { get; set; }

    public int? CustomerVisitFrequency { get; set; }

    public int OwnerId { get; set; }

    public string? TransmissionDate { get; set; }

    public string? CurrencyId { get; set; }

    public int? CustomerBranch { get; set; }

    public int? CustomerCorporationNo { get; set; }

    public int? CustomerAssociationNo { get; set; }

    public int? CustomerHolding { get; set; }

    public int? CustomerCompanyGroup { get; set; }

    public int? CustomerPricelistId { get; set; }
}

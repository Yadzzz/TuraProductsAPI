using System;
using System.Collections.Generic;

namespace TotalEntitiesDataAccessLibrary.Models;

public partial class InItem
{
    public string? Icin { get; set; }

    public int? ItemName { get; set; }

    public int? ItemDescription { get; set; }

    public string SalesItemNo { get; set; } = null!;

    public string Gtin { get; set; } = null!;

    public string? ItemPackBrand { get; set; }

    public string CommodityId { get; set; } = null!;

    public string? CommodityDescription { get; set; }

    public string CommodityMainId { get; set; } = null!;

    public string? CommodityMainDescription { get; set; }

    public string? PartStatusId { get; set; }

    public string? PartStatusDescription { get; set; }

    public int? ItemMoq { get; set; }

    public string? SupplierDescriptionPrimary { get; set; }

    public string SupplierNo { get; set; } = null!;

    public int? SupplierGln { get; set; }

    public string CountryOfOrigin { get; set; } = null!;

    public string PurchaseItemNo { get; set; } = null!;

    public decimal? ItemLength { get; set; }

    public decimal? ItemWidth { get; set; }

    public decimal? ItemHeight { get; set; }

    public decimal? ItemGrossweight { get; set; }

    public int? InnerPackGtin { get; set; }

    public int? InnerPackLenght { get; set; }

    public int? InnerPackWidth { get; set; }

    public int? InnerPackHeight { get; set; }

    public int? InnerPackGrossweight { get; set; }

    public int? InnerPackQty { get; set; }

    public int? McGtin { get; set; }

    public decimal? McLength { get; set; }

    public decimal? McWidth { get; set; }

    public decimal? McHeight { get; set; }

    public decimal? McGrossweight { get; set; }

    public int? McQty { get; set; }

    public int? PackagingPaperShare { get; set; }

    public int? PackagingPlasticShare { get; set; }

    public int? PackagingStrechfoilShare { get; set; }

    public int? TypeOfPackaging { get; set; }

    public int? TypeOfPackagingId { get; set; }

    public int? ImportClassificationNo { get; set; }

    public int? PalletQty { get; set; }

    public int? Container20ftQty { get; set; }

    public int? Container40ftQty { get; set; }

    public int? RecycleableFlag { get; set; }

    public int? RecycleablePackagingFlag { get; set; }

    public int? RohsFlag { get; set; }

    public int? Warranty { get; set; }

    public string? ReplacementItemNo { get; set; }

    public string? ItemCreationDate { get; set; }

    public int? StartAvailabilityDate { get; set; }

    public int? EndAvailabilityDate { get; set; }

    public int? CustomerAvailabilityDate { get; set; }

    public int WebFlag { get; set; }

    public int? WebStartDate { get; set; }

    public int? WebEndDate { get; set; }

    public int? PriceLastPurchase { get; set; }

    public int? CurrencyLastPurchaseId { get; set; }

    public int? ItemBonusFlag { get; set; }

    public int? DeliveryTime { get; set; }

    public int? IntrastatCode { get; set; }

    public int? PriceSrp { get; set; }

    public decimal? StandardPrice { get; set; }

    public int PriceTypeId { get; set; }

    public int PriceCurrencyId { get; set; }

    public int? PackagingUnit { get; set; }

    public int OwnerId { get; set; }

    public string? TransmissionDate { get; set; }

    public int? ReplacementItemNo2 { get; set; }

    public string ItemDescriptionSw { get; set; } = null!;

    public string? ItemDescriptionNo { get; set; }

    public string? ItemDescriptionFi { get; set; }

    public string? ItemDescriptionDk { get; set; }
}

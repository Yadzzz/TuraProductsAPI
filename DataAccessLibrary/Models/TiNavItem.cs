using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavItem
    {
        public byte[] Timestamp { get; set; } = null!;
        public string No { get; set; } = null!;
        public string No2 { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string SearchDescription { get; set; } = null!;
        public string Description2 { get; set; } = null!;
        public string BaseUnitOfMeasure { get; set; } = null!;
        public int PriceUnitConversion { get; set; }
        public int Type { get; set; }
        public string InventoryPostingGroup { get; set; } = null!;
        public string ShelfNo { get; set; } = null!;
        public string ItemDiscGroup { get; set; } = null!;
        public byte AllowInvoiceDisc { get; set; }
        public int StatisticsGroup { get; set; }
        public int CommissionGroup { get; set; }
        public decimal UnitPrice { get; set; }
        public int PriceProfitCalculation { get; set; }
        public decimal Profit { get; set; }
        public int CostingMethod { get; set; }
        public decimal UnitCost { get; set; }
        public decimal StandardCost { get; set; }
        public decimal LastDirectCost { get; set; }
        public decimal IndirectCost { get; set; }
        public byte CostIsAdjusted { get; set; }
        public byte AllowOnlineAdjustment { get; set; }
        public string VendorNo { get; set; } = null!;
        public string VendorItemNo { get; set; } = null!;
        public string LeadTimeCalculation { get; set; } = null!;
        public decimal ReorderPoint { get; set; }
        public decimal MaximumInventory { get; set; }
        public decimal ReorderQuantity { get; set; }
        public string AlternativeItemNo { get; set; } = null!;
        public decimal UnitListPrice { get; set; }
        public decimal DutyDue { get; set; }
        public string DutyCode { get; set; } = null!;
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal UnitsPerParcel { get; set; }
        public decimal UnitVolume { get; set; }
        public string Durability { get; set; } = null!;
        public string FreightType { get; set; } = null!;
        public string TariffNo { get; set; } = null!;
        public decimal DutyUnitConversion { get; set; }
        public string CountryRegionPurchasedCode { get; set; } = null!;
        public decimal BudgetQuantity { get; set; }
        public decimal BudgetedAmount { get; set; }
        public decimal BudgetProfit { get; set; }
        public byte Blocked { get; set; }
        public string BlockReason { get; set; } = null!;
        public DateTime LastDateTimeModified { get; set; }
        public DateTime LastDateModified { get; set; }
        public DateTime LastTimeModified { get; set; }
        public byte PriceIncludesVat { get; set; }
        public string VatBusPostingGrPrice { get; set; } = null!;
        public string GenProdPostingGroup { get; set; } = null!;
        public Guid Picture { get; set; }
        public string CountryRegionOfOriginCode { get; set; } = null!;
        public byte AutomaticExtTexts { get; set; }
        public string NoSeries { get; set; } = null!;
        public string TaxGroupCode { get; set; } = null!;
        public string VatProdPostingGroup { get; set; } = null!;
        public int Reserve { get; set; }
        public string GlobalDimension1Code { get; set; } = null!;
        public string GlobalDimension2Code { get; set; } = null!;
        public int StockoutWarning { get; set; }
        public int PreventNegativeInventory { get; set; }
        public string ApplicationWkshUserId { get; set; } = null!;
        public int AssemblyPolicy { get; set; }
        public string Gtin { get; set; } = null!;
        public string DefaultDeferralTemplateCode { get; set; } = null!;
        public int LowLevelCode { get; set; }
        public decimal LotSize { get; set; }
        public string SerialNos { get; set; } = null!;
        public DateTime LastUnitCostCalcDate { get; set; }
        public decimal RolledUpMaterialCost { get; set; }
        public decimal RolledUpCapacityCost { get; set; }
        public decimal Scrap { get; set; }
        public byte InventoryValueZero { get; set; }
        public int DiscreteOrderQuantity { get; set; }
        public decimal MinimumOrderQuantity { get; set; }
        public decimal MaximumOrderQuantity { get; set; }
        public decimal SafetyStockQuantity { get; set; }
        public decimal OrderMultiple { get; set; }
        public string SafetyLeadTime { get; set; } = null!;
        public int FlushingMethod { get; set; }
        public int ReplenishmentSystem { get; set; }
        public decimal RoundingPrecision { get; set; }
        public string SalesUnitOfMeasure { get; set; } = null!;
        public string PurchUnitOfMeasure { get; set; } = null!;
        public string TimeBucket { get; set; } = null!;
        public int ReorderingPolicy { get; set; }
        public byte IncludeInventory { get; set; }
        public int ManufacturingPolicy { get; set; }
        public string ReschedulingPeriod { get; set; } = null!;
        public string LotAccumulationPeriod { get; set; } = null!;
        public string DampenerPeriod { get; set; } = null!;
        public decimal DampenerQuantity { get; set; }
        public decimal OverflowLevel { get; set; }
        public string ManufacturerCode { get; set; } = null!;
        public string ItemCategoryCode { get; set; } = null!;
        public byte CreatedFromNonstockItem { get; set; }
        public string ProductGroupCode { get; set; } = null!;
        public string ServiceItemGroup { get; set; } = null!;
        public string ItemTrackingCode { get; set; } = null!;
        public string LotNos { get; set; } = null!;
        public string ExpirationCalculation { get; set; } = null!;
        public string WarehouseClassCode { get; set; } = null!;
        public string SpecialEquipmentCode { get; set; } = null!;
        public string PutAwayTemplateCode { get; set; } = null!;
        public string PutAwayUnitOfMeasureCode { get; set; } = null!;
        public string PhysInvtCountingPeriodCode { get; set; } = null!;
        public DateTime LastCountingPeriodUpdate { get; set; }
        public byte UseCrossDocking { get; set; }
        public DateTime NextCountingStartDate { get; set; }
        public DateTime NextCountingEndDate { get; set; }
        public Guid Id { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public Guid TaxGroupId { get; set; }
        public byte WeeeDirective { get; set; }
        public byte SerialNumberRegistration { get; set; }
        public string SalesVolumeCode { get; set; } = null!;
        public string ActivityCode { get; set; } = null!;
        public decimal AvailableQtyToPromise { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime LastCalculated { get; set; }
        public string UnspscCode { get; set; } = null!;
        public int ItemType { get; set; }
        public DateTime DateCreated { get; set; }
        public byte DoNotExportToSolo { get; set; }
        public string ReplacesItemNo { get; set; } = null!;
        public string PackageType { get; set; } = null!;
        public string PickZone { get; set; } = null!;
        public string BaseunitForInnerCarton { get; set; } = null!;
        public string BaseunitForMasterCarton { get; set; } = null!;
        public string BaseunitForPallet { get; set; } = null!;
        public byte NotDivisibleUnit { get; set; }
        public string PrimaryEanCode { get; set; } = null!;
        public string Choice { get; set; } = null!;
        public string BaseunitForElkjop { get; set; } = null!;
        public byte InternetCode { get; set; }
        public byte ExcludeInPriceFile { get; set; }
        public string ItemFeeCode { get; set; } = null!;
        public byte DoNotExportToAstro { get; set; }
        public string NoTariffNo { get; set; } = null!;
        public string WipExternalId1 { get; set; } = null!;
        public string WipExternalId2 { get; set; } = null!;
        public string WipExternalId3 { get; set; } = null!;
        public string RoutingNo { get; set; } = null!;
        public string ProductionBomNo { get; set; } = null!;
        public decimal SingleLevelMaterialCost { get; set; }
        public decimal SingleLevelCapacityCost { get; set; }
        public decimal SingleLevelSubcontrdCost { get; set; }
        public decimal SingleLevelCapOvhdCost { get; set; }
        public decimal SingleLevelMfgOvhdCost { get; set; }
        public decimal OverheadRate { get; set; }
        public decimal RolledUpSubcontractedCost { get; set; }
        public decimal RolledUpMfgOvhdCost { get; set; }
        public decimal RolledUpCapOverheadCost { get; set; }
        public int OrderTrackingPolicy { get; set; }
        public byte Critical { get; set; }
        public string CommonItemNo { get; set; } = null!;
    }
}

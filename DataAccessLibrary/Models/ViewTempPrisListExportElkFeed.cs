using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class ViewTempPrisListExportElkFeed
    {
        public string CustomerNo { get; set; } = null!;
        public string ItemNo { get; set; } = null!;
        public string? SweDescription { get; set; }
        public string? SweDescription2 { get; set; }
        public string? NorDescription { get; set; }
        public string? NorDescription2 { get; set; }
        public string? FinDescription { get; set; }
        public string? FinDescription2 { get; set; }
        public string? DanDescription { get; set; }
        public string? DanDescription2 { get; set; }
        public string? EngDescription { get; set; }
        public string? EngDescription2 { get; set; }
        public string Gtin { get; set; } = null!;
        public string ManufactureCode { get; set; } = null!;
        public string ManufactureName { get; set; } = null!;
        public string VendorItemNo { get; set; } = null!;
        public string? SweWipCat1 { get; set; }
        public string? SweWipCat2 { get; set; }
        public string? SweWipCat3 { get; set; }
        public string? NorWipCat1 { get; set; }
        public string? NorWipCat2 { get; set; }
        public string? NorWipCat3 { get; set; }
        public string? FinWipCat1 { get; set; }
        public string? FinWipCat2 { get; set; }
        public string? FinWipCat3 { get; set; }
        public string? DanWipCat1 { get; set; }
        public string? DanWipCat2 { get; set; }
        public string? DanWipCat3 { get; set; }
        public string? EngWipCat1 { get; set; }
        public string? EngWipCat2 { get; set; }
        public string? EngWipCat3 { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal? Cubage { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public string CountryOfOrigin { get; set; } = null!;
        public string EuCommodityCode { get; set; } = null!;
        public string NoCommodityCode { get; set; } = null!;
        public string? CurrencyCode { get; set; }
        public decimal? Fee { get; set; }
        public string ActivityCode { get; set; } = null!;
        public string? ActivityCodeDescription { get; set; }
        public string? ActivityCodeStatus { get; set; }
        public string? ItemCrossRef { get; set; }
        public string? ItemSub { get; set; }
        public decimal? Packaging { get; set; }
        public decimal? PackagingMaster { get; set; }
        public decimal? PackagingPallet { get; set; }
        public byte NotDivisibleUnit { get; set; }
        public DateTime ItemDateCreated { get; set; }
        public DateTime ItemLastDateModified { get; set; }
        public string Unspsc { get; set; } = null!;
        public string ItemCategoryCode { get; set; } = null!;
        public string ItemProductGroupCode { get; set; } = null!;
        public string ReplacesItemNo { get; set; } = null!;
        public string ItemFeeCode { get; set; } = null!;
        public string? ItemFeeDescription { get; set; }
        public string? ItemFeeResource { get; set; }
        public int? ItemFeeType { get; set; }
        public int ItemType { get; set; }
        public string WipExternalId3 { get; set; } = null!;
        public string? WebTextSwe { get; set; }
        public string? WebTextNor { get; set; }
        public string? WebTextFin { get; set; }
        public string? WebTextDan { get; set; }
        public string? WebTextEng { get; set; }
        public string? FeeResourceSe { get; set; }
        public string? FeeResourceNo { get; set; }
        public string? FeeResourceFi { get; set; }
        public string? FeeResourceDk { get; set; }
        public int? FeeTypSe { get; set; }
        public int? FeeTypNo { get; set; }
        public int? FeeTypFi { get; set; }
        public int? FeeTypDk { get; set; }
    }
}

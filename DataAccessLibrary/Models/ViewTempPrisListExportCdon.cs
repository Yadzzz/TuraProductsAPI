using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class ViewTempPrisListExportCdon
    {
        public string Customer { get; set; } = null!;
        public string Item { get; set; } = null!;
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
        public string? ItemCategoryCode { get; set; }
        public string VendorNo { get; set; } = null!;
        public string? VendorName { get; set; }
        public string VendorItemNo { get; set; } = null!;
        public string PrimaryEanCode { get; set; } = null!;
        public string? CurrencyCode { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal? Cubage { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public string EuTariffNo { get; set; } = null!;
        public string NoTariffNo { get; set; } = null!;
        public decimal? Fee { get; set; }
        public string ActivityCode { get; set; } = null!;
        public decimal? SalesPrice { get; set; }
        public decimal? LineDiscountPerc { get; set; }
        public string CountryRegionOfOriginCode { get; set; } = null!;
        public string? ItemCrossRef { get; set; }
        public string? ItemSub { get; set; }
        public decimal? PriceGroupRek { get; set; }
        public decimal? Packaging { get; set; }
        public byte? SalesPriceAllowLineDisc { get; set; }
        public string? ItemGroup { get; set; }
        public string ProductGroupCode { get; set; } = null!;
        public string ManufactureName { get; set; } = null!;
        public byte NotDivisibleUnit { get; set; }
        public decimal? PackagingMaster { get; set; }
        public decimal? PackagingPallet { get; set; }
        public string ItemDiscountGroup { get; set; } = null!;
        public string? WipCat1 { get; set; }
        public string? WipCat2 { get; set; }
        public string? WipCat3 { get; set; }
        public DateTime ItemLastDateModified { get; set; }
        public DateTime ItemDateCreated { get; set; }
        public int ItemType { get; set; }
        public decimal? VatSe { get; set; }
        public decimal? VatNo { get; set; }
        public decimal? VatDk { get; set; }
        public decimal? VatFi { get; set; }
        public string? SeWebText { get; set; }
        public string? NoWebText { get; set; }
        public string? DkWebText { get; set; }
        public string? FiWebText { get; set; }
        public string? EnWebText { get; set; }
    }
}

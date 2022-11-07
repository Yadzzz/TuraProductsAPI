using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class ViewTempPrisListExportSingle
    {
        public string Customer { get; set; } = null!;
        public string Item { get; set; } = null!;
        public string? Description { get; set; }
        public string? ProdGroupCodeDescrip { get; set; }
        public string? ItemCategoryCode { get; set; }
        public string? ItemCategoryDescrip { get; set; }
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
        public string TariffNo { get; set; } = null!;
        public decimal? Fee { get; set; }
        public decimal? QtyOnPurch { get; set; }
        public string ActivityCode { get; set; } = null!;
        public string? Eeno { get; set; }
        public string PackageType { get; set; } = null!;
        public decimal? ResQty { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? LineDiscountPerc { get; set; }
        public decimal? QtyOnSalesOrder { get; set; }
        public string? Description2 { get; set; }
        public string CountryRegionOfOriginCode { get; set; } = null!;
        public string? ItemCrossRef { get; set; }
        public string? ItemSub { get; set; }
        public decimal? PriceGroupRek { get; set; }
        public decimal? Packaging { get; set; }
        public byte? SalesPriceAllowLineDisc { get; set; }
        public int ItemGroup { get; set; }
        public string ProductGroupCode { get; set; } = null!;
        public string ManufactureName { get; set; } = null!;
        public string SalesVolumeCode { get; set; } = null!;
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
        public string NoTariffNo { get; set; } = null!;
        public decimal? VatRate { get; set; }
    }
}

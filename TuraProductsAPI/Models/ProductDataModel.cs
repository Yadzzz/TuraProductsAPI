namespace TuraProductsAPI.Models
{
    public class ProductDataModel
    {
        //ProductDescriptions
        public string VariantId { get; set; } = null!;
        public string? BaseId { get; set; }
        public string? Gtin { get; set; }
        public int? ActivityCode { get; set; }
        public string? ManufacturerItemNo { get; set; }
        public string? Brand { get; set; }
        public string? SeItemName { get; set; }
        public string? SeItemText { get; set; }
        public string? NoItemName { get; set; }
        public string? NoItemText { get; set; }
        public string? DkItemName { get; set; }
        public string? DkItemText { get; set; }
        public string? FiItemName { get; set; }
        public string? FiItemText { get; set; }
        public string? EnItemName { get; set; }
        public string? EnItemText { get; set; }

        //SalesPrices
        public byte[] Timestamp { get; set; } = null!;
        public string ItemNo { get; set; } = null!;
        public int SalesType { get; set; }
        public string SalesCode { get; set; } = null!;
        public DateTime StartingDate { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public string VariantCode { get; set; } = null!;
        public string UnitOfMeasureCode { get; set; } = null!;
        public decimal MinimumQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public byte PriceIncludesVat { get; set; }
        public byte AllowInvoiceDisc { get; set; }
        public string VatBusPostingGrPrice { get; set; } = null!;
        public DateTime EndingDate { get; set; }
        public byte AllowLineDisc { get; set; }

        //TiNavItem data
        public string PrimaryEANCode { get; set; }
        public string UnitOfMeasure { get; set; }

        //TiNavQtyTmp
        public decimal AvailableQty { get; set; }

        //TiNavItemUnitOfMeasure
        public decimal QtyPerUnitOfMeasure { get; set; }

        //Price withtout vat
        public decimal UnitPriceWithoutVat { get; set; }

        public void SetProductDescriptionData(DataAccessLibrary.Models.TiLitProductDescription tiLitProductDescription)
        {
            this.VariantId = tiLitProductDescription.VariantId;
            this.BaseId = tiLitProductDescription.BaseId;
            this.Gtin = tiLitProductDescription.Gtin;
            this.ActivityCode = tiLitProductDescription.ActivityCode;
            this.ManufacturerItemNo = tiLitProductDescription.ManufacturerItemNo;
            this.Brand = tiLitProductDescription.Brand;
            this.SeItemName = tiLitProductDescription.SeItemName;
            this.SeItemText = tiLitProductDescription.SeItemText;
            this.NoItemName = tiLitProductDescription.NoItemName;
            this.NoItemText = tiLitProductDescription.NoItemText;
            this.DkItemName = tiLitProductDescription.DkItemName;
            this.DkItemText = tiLitProductDescription.DkItemText;
            this.FiItemName = tiLitProductDescription.FiItemName;
            this.FiItemText = tiLitProductDescription.FiItemText;
            this.EnItemName = tiLitProductDescription.EnItemName;
            this.EnItemText = tiLitProductDescription.EnItemText;
        }

        public void SetSalesPrices(DataAccessLibrary.Models.TiNavSalesPrice tiNavSalesPrice)
        {
            this.Timestamp = tiNavSalesPrice.Timestamp;
            this.ItemNo = tiNavSalesPrice.ItemNo;
            this.SalesType = tiNavSalesPrice.SalesType;
            this.SalesCode = tiNavSalesPrice.SalesCode;
            this.StartingDate = tiNavSalesPrice.StartingDate;
            this.CurrencyCode = tiNavSalesPrice.CurrencyCode;
            this.VariantCode = tiNavSalesPrice.VariantCode;
            this.UnitOfMeasureCode = tiNavSalesPrice.UnitOfMeasureCode;
            this.MinimumQuantity = tiNavSalesPrice.MinimumQuantity;
            this.UnitPrice = tiNavSalesPrice.UnitPrice;
            this.PriceIncludesVat = tiNavSalesPrice.PriceIncludesVat;
            this.AllowInvoiceDisc = tiNavSalesPrice.AllowInvoiceDisc;
            this.VatBusPostingGrPrice = tiNavSalesPrice.VatBusPostingGrPrice;
            this.EndingDate = tiNavSalesPrice.EndingDate;
            this.AllowLineDisc = tiNavSalesPrice.AllowLineDisc;
        }

        public void SetItem(DataAccessLibrary.Models.TiNavItem tiNavItem)
        {
            this.PrimaryEANCode = tiNavItem.PrimaryEanCode;
            this.UnitOfMeasure = tiNavItem.BaseUnitOfMeasure;
        }

        public void SetQtyTmp(DataAccessLibrary.Models.TiNavQtyTmp tiNavQtyTmp)
        {
            this.AvailableQty = tiNavQtyTmp.AvailableQty;
        }

        public void SetItemUnitOfMeasure(DataAccessLibrary.Models.TiNavItemUnitOfMeasure tiNavItemUnitOfMeasure)
        {
            this.QtyPerUnitOfMeasure = tiNavItemUnitOfMeasure.QtyPerUnitOfMeasure;
        }
        
        public void SetUnitPriceWithoutVat(decimal price)
        {
            this.UnitPriceWithoutVat = price;
        }
    }
}

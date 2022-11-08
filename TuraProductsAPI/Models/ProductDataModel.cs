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

        public void SetProductDescriptionData(string variandId, string? baseId, string? gtin, int? activityCode, string? manufacturerItemNo,
                                                string? brand, string? seItemName, string? seItemText, string? noItemName, string? noItemText,
                                                string? dkItemName, string? dkItemText, string? fiItemName, string? fiItemText, string? enItemName,
                                                string? enItemText)
        {
            this.VariantId = variandId;
            this.BaseId = baseId;
            this.Gtin = gtin;
            this.ActivityCode = activityCode;
            this.ManufacturerItemNo = manufacturerItemNo;
            this.Brand = brand;
            this.SeItemName = seItemName;
            this.SeItemText = seItemText;
            this.NoItemName = noItemName;
            this.NoItemText = noItemText;
            this.DkItemName = dkItemName;
            this.DkItemText = dkItemText;
            this.FiItemName = fiItemName;
            this.FiItemText = fiItemText;
            this.EnItemName = enItemName;
            this.EnItemText = enItemText;
        }

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

        public void SetSalesPrices(byte[] timestamp, string itemNo, int salesType, string salesCode, DateTime startingDate, string currencyCode, string variantCode,
                                    string unitOfMeasureCode, decimal minimumQuantity, decimal unitPrice, byte priceIncludesVat, byte allowInvoiceDisc,
                                    string vatBusPostingGrPrice, DateTime endingDate, byte allowLineDisc)
        {
            this.Timestamp = timestamp;
            this.ItemNo = itemNo;
            this.SalesType = salesType;
            this.SalesCode = salesCode;
            this.StartingDate = startingDate;
            this.CurrencyCode = currencyCode;
            this.VariantCode = variantCode;
            this.UnitOfMeasureCode = unitOfMeasureCode;
            this.MinimumQuantity = minimumQuantity;
            this.UnitPrice = unitPrice;
            this.PriceIncludesVat = priceIncludesVat;
            this.AllowInvoiceDisc= allowInvoiceDisc;
            this.VatBusPostingGrPrice = vatBusPostingGrPrice;
            this.EndingDate= endingDate;
            this.AllowLineDisc= allowLineDisc;
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
    }
}

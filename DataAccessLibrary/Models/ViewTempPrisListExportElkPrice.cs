using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class ViewTempPrisListExportElkPrice
    {
        public string Customer { get; set; } = null!;
        public string Item { get; set; } = null!;
        public string VendorItemNo { get; set; } = null!;
        public string PrimaryEanCode { get; set; } = null!;
        public string? ItemCrossRef { get; set; }
        public decimal? NetPriceNok { get; set; }
        public decimal? NetPriceSek { get; set; }
        public decimal? NetPriceDkk { get; set; }
        public decimal? NetPriceEur { get; set; }
        public decimal? RecommendedPriceNok { get; set; }
        public decimal? RecommendedPriceSek { get; set; }
        public decimal? RecommendedPriceDkk { get; set; }
        public decimal? RecommendedPriceEur { get; set; }
        public string ActivityCode { get; set; } = null!;
        public string StatusPriceFile { get; set; } = null!;
        public string? ItemSub { get; set; }
        public int ItemType { get; set; }
    }
}

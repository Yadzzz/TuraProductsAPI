using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class ViewTempPrisListExportElkPlife
    {
        public string No { get; set; } = null!;
        public string PrimaryEanCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string StatusPriceFile { get; set; } = null!;
        public string? ItemSub { get; set; }
        public string ItemCategoryCode { get; set; } = null!;
        public byte ExcludeInPriceFile { get; set; }
        public int ItemType { get; set; }
        public decimal? AvailableQty { get; set; }
        public DateTime LastDateTimeModified { get; set; }
        public string VendorItemNo { get; set; } = null!;
        public string VendorNo { get; set; } = null!;
        public string ManufacturerCode { get; set; } = null!;
        public string ActivityCode { get; set; } = null!;
    }
}

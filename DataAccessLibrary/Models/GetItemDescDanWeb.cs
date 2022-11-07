using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class GetItemDescDanWeb
    {
        public string TuraItemNo { get; set; } = null!;
        public string? ProductName { get; set; }
        public string VendorItemNo { get; set; } = null!;
        public string Eancode { get; set; } = null!;
        public string ManufacturerCode { get; set; } = null!;
        public string WebCat1 { get; set; } = null!;
        public string WebCat2 { get; set; } = null!;
        public string WebCat3 { get; set; } = null!;
        public string? ProductDescriptionDan { get; set; }
    }
}

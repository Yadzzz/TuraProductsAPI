using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavItemFeeTranslation
    {
        public byte[] Timestamp { get; set; } = null!;
        public string ItemFee { get; set; } = null!;
        public string LanguageCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Description2 { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavItemFee1
    {
        public byte[] Timestamp { get; set; } = null!;
        public string ItemNo { get; set; } = null!;
        public string FeeCode { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavItemFee
    {
        public byte[] Timestamp { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ResourceNo { get; set; } = null!;
        public int FeeType { get; set; }
        public decimal? Discount { get; set; }
    }
}

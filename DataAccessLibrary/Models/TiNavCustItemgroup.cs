using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavCustItemgroup
    {
        public byte[] Timestamp { get; set; } = null!;
        public string CustomerNo { get; set; } = null!;
        public string CustomerChain { get; set; } = null!;
        public string ItemNo { get; set; } = null!;
        public string ItemGroupNo { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
    }
}

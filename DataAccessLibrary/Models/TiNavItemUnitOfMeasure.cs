using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavItemUnitOfMeasure
    {
        public byte[] Timestamp { get; set; } = null!;
        public string ItemNo { get; set; } = null!;
        public string Code { get; set; } = null!;
        public decimal QtyPerUnitOfMeasure { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Cubage { get; set; }
        public decimal Weight { get; set; }
    }
}

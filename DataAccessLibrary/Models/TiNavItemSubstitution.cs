using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavItemSubstitution
    {
        public byte[] Timestamp { get; set; } = null!;
        public int Type { get; set; }
        public string No { get; set; } = null!;
        public string VariantCode { get; set; } = null!;
        public int SubstituteType { get; set; }
        public string SubstituteNo { get; set; } = null!;
        public string SubstituteVariantCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Inventory { get; set; }
        public byte Interchangeable { get; set; }
        public int RelationsLevel { get; set; }
        public decimal QuantityAvailOnShptDate { get; set; }
        public DateTime ShipmentDate { get; set; }
    }
}

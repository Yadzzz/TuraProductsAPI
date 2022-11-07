using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavItemEnvironmentalReporting
    {
        public byte[] Timestamp { get; set; } = null!;
        public string ItemNo { get; set; } = null!;
        public string WeeeId { get; set; } = null!;
        public decimal? WeeeWeight { get; set; }
        public decimal PackagingWeightCarton { get; set; }
        public decimal PackagingWeightPlastic { get; set; }
        public decimal PackagingWeightDiverse { get; set; }
        public string BatteryType { get; set; } = null!;
        public int BatteryQty { get; set; }
        public decimal BatteryWeight { get; set; }
        public byte Ce { get; set; }
        public byte Gruenerpunkt { get; set; }
        public string EnergyLabel { get; set; } = null!;
        public string DangerousGodsNumber { get; set; } = null!;
        public decimal DangerousGodsWeight { get; set; }
        public string WeeeIdFi { get; set; } = null!;
        public string WeeeIdDk { get; set; } = null!;
    }
}

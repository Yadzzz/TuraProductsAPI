using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavPrisexportSetup
    {
        public byte[] Timestamp { get; set; } = null!;
        public string PrimaryKey { get; set; } = null!;
        public string OutgoingFilesFolder { get; set; } = null!;
        public string LocationFilter { get; set; } = null!;
        public string LeadTimeCalculation { get; set; } = null!;
        public string CustomerPricegroupEndcustome { get; set; } = null!;
        public string ActivityFilter { get; set; } = null!;
        public int ItemAvailReCalcMinutes { get; set; }
    }
}

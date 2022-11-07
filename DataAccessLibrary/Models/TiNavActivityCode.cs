using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavActivityCode
    {
        public byte[] Timestamp { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string SoloDeliveryCode { get; set; } = null!;
        public byte InsuffInvNotAllowedOnSol { get; set; }
        public string ActivityCodeForNegInventor { get; set; } = null!;
        public string ActivityCodeForPosInventor { get; set; } = null!;
        public string LocationFilter { get; set; } = null!;
        public string StandardtextForActivitycode { get; set; } = null!;
        public byte ReturnNotAllowed { get; set; }
        public string StatusPriceFile { get; set; } = null!;
    }
}

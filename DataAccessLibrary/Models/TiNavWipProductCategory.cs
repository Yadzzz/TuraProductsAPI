using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavWipProductCategory
    {
        public byte[] Timestamp { get; set; } = null!;
        public string ExternalIdentifier { get; set; } = null!;
        public int EnovaId { get; set; }
        public string Identifier { get; set; } = null!;
        public DateTime Modified { get; set; }
        public string NameSv { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string NameNo { get; set; } = null!;
        public string NameFi { get; set; } = null!;
        public string NameDk { get; set; } = null!;
        public long Tsnumber { get; set; }
        public byte IsDeleted { get; set; }
    }
}

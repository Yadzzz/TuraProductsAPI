using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavItemCategory
    {
        public byte[] Timestamp { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string ParentCategory { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Indentation { get; set; }
        public int PresentationOrder { get; set; }
        public byte HasChildren { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public Guid Id { get; set; }
        public string EeNo { get; set; } = null!;
    }
}

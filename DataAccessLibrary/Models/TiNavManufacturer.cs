using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavManufacturer
    {
        public byte[] Timestamp { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}

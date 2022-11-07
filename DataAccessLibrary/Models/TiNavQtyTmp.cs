using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class TiNavQtyTmp
    {
        public string Item { get; set; } = null!;
        public decimal QtyOnPurch { get; set; }
        public decimal ResQty { get; set; }
        public decimal QtyOnSalesOrder { get; set; }
        public DateTime PlanedDate { get; set; }
        public decimal AvailableQty { get; set; }
        public decimal AvailableQtyNoDate { get; set; }
        public decimal QtyOnInventory { get; set; }
        public decimal QtyOnSalesOrderNoDate { get; set; }
    }
}

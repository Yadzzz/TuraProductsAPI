using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraProductsAPI.Services.Intranet.Orders
{
    public class O08T1
    {
        public string ordno { get; set; }
        public System.DateTime regdate { get; set; }
        public short linestat { get; set; }
        public System.DateTime statdate { get; set; }
        public string partno { get; set; }
        public string partdsc1 { get; set; }
        public decimal reqquant { get; set; }
        public decimal delquant { get; set; }
        public string ordline2 { get; set; }
        public string eorderid { get; set; }
    }
}

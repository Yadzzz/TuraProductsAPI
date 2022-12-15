using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraProductsAPI.Services.PDF
{
    public abstract class DocumentCreatorFactory
    {
        public abstract IDocument CreateInvoice();
    }
}

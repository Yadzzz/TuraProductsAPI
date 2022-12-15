using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraProductsAPI.Services.PDF
{
    public class ConcreteDocumentsCreator : DocumentCreatorFactory
    {
        public override IDocument CreateInvoice()
        {
            return null;
        }
    }
}

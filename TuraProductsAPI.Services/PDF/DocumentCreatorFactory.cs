using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraProductsAPI.Services.PDF
{
    public abstract class DocumentCreatorFactory
    {
        public abstract IDocument CreateInvoiceDocument(string documentNumber);
        public abstract IDocument CreateDeliveryDocument(string documentNumber);
        public abstract IDocument CreateConfirmationDocument(string documentNumber);
        public abstract IDocument CreateInterestDocument(string documentNumber);
        public abstract IDocument CreateReturnDocument(string documentNumber);
    }
}

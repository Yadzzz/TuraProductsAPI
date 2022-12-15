using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraProductsAPI.Services.PDF.Documents;

namespace TuraProductsAPI.Services.PDF
{
    public class ConcreteDocumentsCreator : DocumentCreatorFactory
    {
        public override InvoiceDocument CreateInvoiceDocument(string documentNumber)
        {
            return new InvoiceDocument(documentNumber, DocumentType.Invoice);
        }

        public override DeliveryDocument CreateDeliveryDocument(string documentNumber)
        {
            return new DeliveryDocument(documentNumber, DocumentType.Delivery);
        }

        public override IDocument CreateConfirmationDocument(string documentNumber)
        {
            return new ConfirmationDocument(documentNumber, DocumentType.Confirmation);
        }

        public override IDocument CreateInterestDocument(string documentNumber)
        {
            return new InterestDocument(documentNumber, DocumentType.Interest);
        }

        public override IDocument CreateReturnDocument(string documentNumber)
        {
            return new ReturnDocument(documentNumber, DocumentType.Return);
        }
    }
}

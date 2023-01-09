using StreamServiceDataAccessLibrary.Models;
using TuraProductsAPI.Services.PDF;
using TuraProductsAPI.Services.PDF.Documents;

namespace TuraProductsAPI.Services
{
    public class PdfService
    {
        public DocumentData GetDocumentData(string documentNumber, string type)
        {
            if(type.ToLower() == "invoice")
            {
                return this.GetInvoice(documentNumber);
            }
            else if(type.ToLower() == "delivery")
            {
                return this.GetDelivery(documentNumber);
            }
            else if(type.ToLower() == "confirmation")
            {
                return this.GetConfirmation(documentNumber);
            }
            else if (type.ToLower() == "interest")
            {
                return this.GetInterest(documentNumber);
            }
            else if (type.ToLower() == "return")
            {
                return this.GetReturn(documentNumber);
            }
            else
            {
                return null;
            }
        }

        public DocumentData GetInvoice(string documentNumber)
        {
            ConcreteDocumentsCreator documenctCreator = new ConcreteDocumentsCreator();
            var invoice = documenctCreator.CreateInvoiceDocument(documentNumber);

            if (invoice == null)
            {
                return null;
            }

            var documentData = invoice.GetDocumentData();

            if (documentData == null || documentData.Data == null)
            {
                return null;
            }

            return documentData;
        }

        public DocumentData GetDelivery(string documentNumber)
        {
            ConcreteDocumentsCreator documentCreator = new ConcreteDocumentsCreator();
            var delivery = documentCreator.CreateDeliveryDocument(documentNumber);

            if(delivery == null)
            {
                return null;
            }

            DocumentData? documentData= delivery.GetDocumentData();

            if(documentData == null || documentData.Data == null)
            {
                return null;
            }

            return documentData;
        }

        public DocumentData GetConfirmation(string documentNumber)
        {
            ConcreteDocumentsCreator documentCreator = new ConcreteDocumentsCreator();
            var delivery = documentCreator.CreateConfirmationDocument(documentNumber);

            if (delivery == null)
            {
                return null;
            }

            DocumentData? documentData = delivery.GetDocumentData();

            if (documentData == null || documentData.Data == null)
            {
                return null;
            }

            return documentData;
        }

        public DocumentData GetInterest(string documentNumber)
        {
            ConcreteDocumentsCreator documentCreator = new ConcreteDocumentsCreator();
            var delivery = documentCreator.CreateInterestDocument(documentNumber);

            if (delivery == null)
            {
                return null;
            }

            DocumentData? documentData = delivery.GetDocumentData();

            if (documentData == null || documentData.Data == null)
            {
                return null;
            }

            return documentData;
        }

        public DocumentData GetReturn(string documentNumber)
        {
            ConcreteDocumentsCreator documentCreator = new ConcreteDocumentsCreator();
            var delivery = documentCreator.CreateReturnDocument(documentNumber);

            if (delivery == null)
            {
                return null;
            }

            DocumentData? documentData = delivery.GetDocumentData();

            if (documentData == null || documentData.Data == null)
            {
                return null;
            }

            return documentData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraProductsAPI.Services.PDF
{
    public class PdfManager
    {
        private readonly string _invoiceNumber;
        private readonly DocumentType _pdfType;

        public PdfManager(string invoiceNumber, DocumentType pdfType)
        {
            this._invoiceNumber = invoiceNumber;
            this._pdfType = pdfType;
        }

        public void GetPdf()
        {

        }

        public void DeletePdf()
        {

        }
    }
}

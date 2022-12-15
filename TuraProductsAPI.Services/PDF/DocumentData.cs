using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraProductsAPI.Services.PDF
{
    public class DocumentData
    {
        public string InvoicdeNumber { get; set; }
        public DocumentType PdfType { get; set; }
        public byte[] Data { get; set; }

        public DocumentData(string invoicdeNumber, DocumentType pdfType, byte[] data)
        {
            this.InvoicdeNumber = invoicdeNumber;
            this.PdfType = pdfType;
            this.Data = data;
        }
    }
}
